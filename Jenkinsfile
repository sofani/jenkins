
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
       dir('JenkinsMvc.Test') {
            bat 'dotnet restore'
            bat 'msbuild /t:build JenkinsMvc.Test.csproj'
            bat 'dotnet test'
        }
      } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('package') {
    try {
      dir('JenkinsMvc') {
       bat 'dotnet publish JenkinsMvc.csproj --output ../Package'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('deploy') {
    try {
      // bat 'dotnet build ./JenkinsMvc/JenkinsMvc.csproj /p:DeployOnBuild=true /p:PublishProfile=publish'
      // bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\jenkinsops\\Package\\" -dest:iisApp="Default Web Site/jenkinsops" ,
      // computername=ec2-34-229-104-72.compute-1.amazonaws.com:8172/msdploy.axd,username=Administrator,password="95-oyE8d6jocCPxnq((M**Oa-HMLpL2r" -allowUntrusted -enableRule:AppOffline'
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }
}