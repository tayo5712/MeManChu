# 배포가이드

## 백엔드 없을때

랭킹 기록 및 로그인 데이터 미관리

- 유니티 허브 다운로드
- 유니티 에디터 버전 2021.3.9f1
- project 오픈
- project/Assets/02.Scripts/User/btnLogin.cs 수정

  - 32번째줄 주석처리
  - 33번, 34번. 35번 줄 주석처리 풀기
- Window -> Photon Unity Networking -> PUN Wizard -> Setup Project -> AppId or Email 자기 photon Id 발급해서 수정
- project/Assets/02_Scripts 의 ChatTest 30번째 줄 수정

  - hatClient.Connect("포톤 챗 ID를 발급받아 넣기", "1.0", new AuthenticationValues(userName));
- File -> Build Settings

  - 01.Scenes/JDH/TESTGO
  - 01.Scenes/JDH/Floor3
  - 01.Scenes/Fire_2
  - 01.Scenes/Fire_1
  - 01.Scenes/MainScene
  - 01.Scenes/SsafyRun
  - 01.Scenes/JDH/Giantroom
  - 01.Scenes/JDH/LoadingP/Loading
  - 01.Scenes/JDH/LoadingP/Loading2
  - 01.Scenes/CharactorSelect
  - 01.Scenes/MiniGame
  - 01.Scenes/HorrorHouse
  - Photon/PhotonChat/Demose/DemoChat/DemoChat-Scene
  - 01.Scenes/JDH/LoadingP/Loading_Run
  - 01.Scenes/JDH/LoadingP/Loading_Horror
  - 01.Scenes/JDH/LoadingP/Loading_Giant
  - 01.Scenes/JDH/LoadingP/Loading_Sky
  - 01.Scenes/JDH/LoadingP/Loading_Fire
- Unity Build

## 백엔드 있을때

- BackServer/README.md 참조하여 백엔드 배포
- 유니티 허브 다운로드
- 유니티 에디터 버전 2021.3.9f1
- project 오픈
- project/Assets/02.Scripts/REST.cs 에 있는 https주소를 모두 백엔드 배포 주소로 수정
- Unity Build
