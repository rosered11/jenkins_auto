node {
    checkout scm
    def customImage = docker.build("rosered/auto-jenkins", "/var/jenkins_home/workspace/auto_test/kubernetes/Dockerfile/demoWeb/Dockerfile")
    customImage.push()
}