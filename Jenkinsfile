pipeline {
    agent any

    environment {
        dockerImage = ''
    }

    stages {
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test test'
            }
        }
        stage('Build image') {
            steps {
                script {
                    dockerImage = docker.build("rosered/auto-jenkins")
                }
            }
        }
        stage('Push image') {
            steps {
                script {
                    withDockerRegistry(
                        credentialsId: '7e5f7acc-0d6f-483e-bb5d-298e681e0f4b',
                        url: 'https://index.docker.io/rosered/auto-jenkins') {
                        dockerImage.push()
                    }
                }
            }
        }
        stage('Deployment') {
            steps {
                sh 'kubectl apply -f kubernetes/deployment.yml';
            }
        }
    }
}