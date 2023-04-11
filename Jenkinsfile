pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
//                 bat 'makewin.cmd' 
              bat 'dotnet publish -r win-x64 -c Release /p:PublishTrimmed=true'
            }
        }

        stage('SCM') {
            steps {
                checkout scm
            }
        }

        stage('SonarQube Analysis') {
            steps {
                script 
                {
                    def scannerHome = tool 'SonarScanner';
                    withSonarQubeEnv() {
                        bat "${scannerHome}/bin/sonar-scanner.bat"
                    }    
                }
                
            }

        }

    }
}
