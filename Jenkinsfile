pipeline {
    agent none
    environment {
        HOME = '/tmp'
    }
    stages {
        stage('test') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0-alpine3.18'
                }
            }
            steps {
                sh 'dotnet test'
            }
        }
        stage('build') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0-alpine3.18'
                }
            }
            steps {
                sh 'dotnet publish src/Tattoo/Tattoo.csproj'
            }
        }
        stage('docker') {
            agent any
            environment {
                DOCKER = credentials("d91fd866-3f46-489f-800a-c8cf5125b17c")
            }
            steps {
                sh 'echo $DOCKER_PSW | docker login -u$DOCKER_USR --password-stdin'
                sh 'docker build -t $DOCKER_USR/tattoo:0.1 .'
                sh 'docker push $DOCKER_USR/tattoo:0.1'
            }
        }
    }
}
