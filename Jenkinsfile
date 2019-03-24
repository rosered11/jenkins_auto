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
                sh 'dotnet publish -c Release -o kubernetes/Dockerfile/demoWeb/ -r linix-x64'
            }
        }
        stage('Docker Tag & Push') {
            steps {
                script {
                    shortCommitHash = getShortCommitHash()
                    IMAGE_VERSION = ${params.SPECIFIER} + "-" + shortCommitHash
                    sh "docker build -f kubernetes/Dockerfile/demoWeb/Dockerfile -t rosered/auto-jenkins ."
                    sh "docker push rosered/auto-jenkins"

                    sh "docker rmi rosered/auto-jenkins"
                }
            }
        }
    }
}
def getShortCommitHash() {
        return sh(returnStdout: true, script: "git log -n 1 --pretty=format:'%h'").trim()
}