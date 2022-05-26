pipeline {
agent any 
stages {
stage ('Clean workspace') {
  steps {
    cleanWs()
  }
}

stage ('Git Checkout') {
  steps {
      git branch: 'master', url: 'https://github.com/ladbhavesh/TestApp'
    }
  }


stage('Restore packages') {
  steps {
    sh "dotnet restore ${workspace}/TestApp.sln"
  }
}

stage('Build') {
  steps {
    sh "dotnet build ${workspace}/TestApp.sln"
  }
}

stage('publish') {
  steps {
    sh "dotnet publish -c Release --output ${workspace}/puboutput ${workspace}/TestApp/TestApp.csproj"
  }
}

stage('dockerize') {
  steps {
    sh "cd  ${workspace}"
    sh "docker build -t  testapp:${currentBuild.number} ."
    
  }
}

stage('docker push') {
  steps {
    withCredentials([usernamePassword(credentialsId: 'docker_secret', passwordVariable: 'pass', usernameVariable: 'user')]) {
            sh "docker tag testapp:${currentBuild.number} $user/testapp:${currentBuild.number}"
            sh "docker tag $user/testapp:${currentBuild.number} $user/testapp:latest"
            sh "docker login -u=$user -p=$pass"
            sh "docker push $user/testapp:${currentBuild.number}"
            sh "docker logout"
            sh "docker rmi testapp:${currentBuild.number}"
            sh "docker rmi $user/testapp:${currentBuild.number}"
        }
   
    
  }
}


  }
}