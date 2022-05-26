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


  }
}