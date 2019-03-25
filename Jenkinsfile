node {
    checkout scm
    def customImage = docker.build("rosered/auto-jenkins", "./kubernetes/Dockerfile/demoWeb/Dockerfile")
    customImage.push()
}