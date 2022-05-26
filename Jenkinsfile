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

  }
}