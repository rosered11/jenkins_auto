pipeline {
    environment {
        registry = "rosered/auto-jenkins"
        registryCredential = 'dockerhub'
        dockerImage = ''
    }
    agent any

    parameters {
        string(defaultValue: "master", description: 'Branch Specifier', name: 'SPECIFIER')
    }

    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'dockerhub', url: 'https://github.com/rosered11/jenkins_auto.git'
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
               sh 'dotnet publish src -c Release -o ../kubernetes/Dockerfile/demoWeb/ -r linux-x64'
           }
        }
        
        stage('Docker Tag & Push') {
           steps {
                script {
                    dockerImage = docker.build(registry, "./kubernetes/Dockerfile/demoWeb") //registry
                }
            }
        }
        stage('Deploy Image'){
            steps{
                script {
                    docker.withRegistry( '', registryCredential ) {
                        dockerImage.push()
                    }
                }
            }
        }
        //stage('Remove Unused docker image') {
        //    steps{
        //        sh "docker rmi $registry"
        //    }
        //}
        stage('Deployment') {
            steps {
                sh 'kubectl apply -f ./kubernetes/deployment.yml';
            }
        }
    }
}