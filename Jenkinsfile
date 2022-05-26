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
   withCredentials([usernamePassword(credentialsId: 'docker_secret', passwordVariable: 'pass', usernameVariable: 'user')]) {
            // the code here can access $pass and $user
            sh "docker login -u=$user -p=$pass"
            sh "docker logout"
        }
    
  }
}

stage('docker push') {
  steps {
    sh "docker "
    sh "docker build -t  testapp:${currentBuild.number} ."
    sh "docker tag testapp:${currentBuild.number} ladbhavesh1/testapp:${currentBuild.number}"
    
  }
}


  }
}