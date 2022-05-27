pipeline {
agent any 
stages {

/*
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
} 

*/
stage('deploy') {

 steps {
    withCredentials([usernamePassword(credentialsId: 'oc_cred', passwordVariable: 'password',usernameVariable: 'user')]) {

    withCredentials([string(credentialsId: 'oc_url', variable: 'oc_url')]) {
            sh "oc login $oc_url -u $user -p $password --insecure-skip-tls-verify"
            sh "cat ${workspace}/deployment.yaml | sed 's/{{version_number}}/${currentBuild.number}/g' | oc apply -f - "

           // sh "oc apply -f ${workspace}/deployment.yaml"
            sh "oc apply -f ${workspace}/service.yaml"
            sh "oc logout"

        }
     }
   
    
  }

}


  }
}