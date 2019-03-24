pipeline {
    agent any

    parameters {
        string(defaultValue: "master", description: 'Branch Specifier', name: 'SPECIFIER')
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: "${params.SPECIFIER}", url: "${GIT_URL}"
            }
        }
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
        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o kubernetes/Dockerfile/demoWeb/ '
            }
        }
        stage('Docker Tag & Push') {
            steps {
                script {
                    sh "sudo docker build -f kubernetes/Dockerfile/demoWeb/Dockerfile -t rosered/auto-jenkins ."
                    sh "sudo docker push rosered/auto-jenkins"

                    sh "sudo docker rmi rosered/auto-jenkins"
                }
            }
        }
    }
}