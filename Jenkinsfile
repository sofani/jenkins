
node('master') {
  stage('import') {
    try {
      git url:'https://github.com/sofani/jenkins.git'
    } catch(error) {
      //slackSend message:{env.BUILD_NUMBER} color:'danger'
    }
  }

  stage('build') {
    try {
      dir('JenkinsMvc') {
        bat 'dotnet restore'
        bat 'msbuild /t:clean,build JenkinsMvc.csproj'
      }
      
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('analyze') {
    try {
      dir('JenkinsMvc') {
        bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe begin /k:jkmvc'
        bat 'msbuild /t:build JenkinsMvc.csproj'
        bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe end'
      }

    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('test') {
    try {
     // dir('JenkinsMvc.Tests') {
     //  bat 'dotnet restore'
    //    bat 'msbuild /t:build JenkinsMVC.Tests.csproj'
      //  bat 'dotnet test'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('package') {
    try {
      dir('JenkinsMvc') {
       // bat 'dotnet publish JenkinsMVC.csproj --output ../Package'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('deploy') {
    try {

    } catch(error) {
      //slackSend message: color:'danger'
    }
  }
}