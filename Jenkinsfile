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

/* stage('dockerize') {
  steps {
    sh "cd  ${workspace}"
    withCredentials([usernamePassword(credentialsId: 'docker_secret', passwordVariable: 'pass', usernameVariable: 'user')]) {
        sh "docker build -t  $user/testapp:${currentBuild.number} -t $user/testapp:latest ."
    }
    
  }
}

 stage('docker push') {
  steps {
    withCredentials([usernamePassword(credentialsId: 'docker_secret', passwordVariable: 'pass', usernameVariable: 'user')]) {
            sh "docker login -u=$user -p=$pass"
            sh "docker push --all-tags $user/testapp"
            sh "docker logout"
            sh "docker rmi $user/testapp:latest"
            sh "docker rmi $user/testapp:${currentBuild.number}"
        }
   
    
  }
} */

stage('deploy') {

 steps {
    withCredentials([string(credentialsId: 'oc_token', variable: 'token')]) {
            sh "oc login --token=$otken"
            sh "oc get pods"
            sh "oc logout"

        }
   
    
  }

}


  }
}