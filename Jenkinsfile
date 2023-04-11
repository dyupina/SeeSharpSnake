pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                powershell 'dotnet publish -r win-x64 -c Release' 
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