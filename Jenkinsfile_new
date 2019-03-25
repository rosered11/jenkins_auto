node {
    checkout scm
    def customImage = docker.build("rosered/auto-jenkins", " -f /var/jenkins_home/workspace/auto_test/kubernetes/Dockerfile/demoWeb/Dockerfile .")
    customImage.push()
}