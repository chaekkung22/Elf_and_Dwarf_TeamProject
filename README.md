# 🧝‍♀️ Elf & Dwarf 🛡️
Unity 입문 챕터 10조의 팀 프로젝트로, [파이어보이 & 워터걸](https://soksok.co.kr/2021/04/22/fireboy-and-watergirl-1/) 게임을 모티브로 제작된 로컬 멀티 2인 협동 퍼즐 게임입니다.  
<br><br>
## 목차
[🎮 프로젝트 소개](#-프로젝트-소개)  
[👥 팀원 소개(블로그 링크)](#-팀원-소개블로그-링크)  
[💻 개발 환경](#-개발-환경)  
[🗓️ 개발 일정](#%EF%B8%8F-개발-일정)  
[🧩 주요 기능](#-주요-기능)  
[📐 와이어 프레임](#-와이어-프레임)  
[🧠 클래스 다이어그램 초기 구조](#-클래스-다이어그램-초기-구조)  
[🐞 트러블 슈팅](#-트러블-슈팅)  
[🎥 시연 영상](#-시연-영상)

---
<br><br>
## 🎮 프로젝트 소개
"엘프와 드워프"는 두 명의 플레이어가 각기 다른 속성을 가진 캐릭터를 조작하여 협력하며 퍼즐을 해결하는 게임입니다. Unity 엔진을 활용하여 제작되었으며, 협동을 통해 다양한 장애물을 극복하고 스테이지를 클리어하는 재미를 제공합니다.
<br><br>
## 👥 팀원 소개(블로그 링크)
![image](https://github.com/user-attachments/assets/fc304062-ab51-4789-b4db-4b0177c33bec)  
[유채영](https://velog.io/@ycy0109/posts)  
 상호 작용 오브젝트, 상점 UI, 인벤토리 UI 구현, 스테이지 생성, 이미지 리소스 제작, 빌드 및 배포  
![image](https://github.com/user-attachments/assets/652a0f46-b8ea-42f9-87a2-0ae1323ce12c)  
[한욱진](https://velog.io/@wh180911/posts)   
UI Manager, Quest 시스템 구현, DataManager 구현  
![image](https://github.com/user-attachments/assets/8e5fc69b-5d48-4bd5-b395-74a82878a9b7)  
[장세희](https://velog.io/@jsh1028/posts)  
캐릭터 구현, 튜토리얼 UI 구현, 맵 제작, 파티클 제작  
![image](https://github.com/user-attachments/assets/31109a43-8caf-47cc-96b2-9cf0ceb1a363)  
[신현수](https://velog.io/@hyeon11ok/posts)  
상호 작용 오브젝트, 스테이지 생성, 메인 화면 UI, 스테이지 선택 UI 기능 구현  
![image](https://github.com/user-attachments/assets/106fc741-662b-4de0-b70a-e264413ef958)  
[김기현](https://fooa.tistory.com/)  
상호 작용 오브젝트, 배경음악과 사운드 효과, 옵션 UI 기능 구현  
<br><br>

## 💻 개발 환경
<br><br>
![image](https://github.com/user-attachments/assets/104f039a-f9a2-4b0b-b3cb-51a0818e7f9f)
<br><br>
## 🗓️ 개발 일정
<br><br>
![image](https://github.com/user-attachments/assets/024540eb-cebe-4945-b92c-9ef775f46dc1)
<br><br>
## 🧩 주요 기능
![LxcJLajvyq](https://github.com/user-attachments/assets/3b55eaf2-9384-4241-9999-423620706b5f)

![Ui4TzLtPas](https://github.com/user-attachments/assets/8590d414-8119-4658-a40e-9ffcfdaa458b) 

**2인 협동 플레이**: 엘프와 드워프 캐릭터를 각각 조작하여 협력 플레이 가능

**다양한 퍼즐 요소**: 레버, 버튼, 속성 체인지, 포탈 등 다양한 퍼즐 기믹 제공

**다양한 스테이지 구성**: 점점 난이도가 상승하는 여러 스테이지로 구성

**맵 해금 시스템** : 스테이지 클리어 시 다음 스테이지 해금
<br><br>

## 📐 와이어 프레임
![image](https://github.com/user-attachments/assets/7091b2f8-469a-4daa-ab25-77145c2fe4ce)

## 🧠 클래스 다이어그램 초기 구조
![image](https://github.com/user-attachments/assets/b1dfb124-fa24-4edf-8726-aaace7f875dd)

## 🐞 트러블 슈팅
### 타일맵 콜라이더 플레이어 끼임 현상
![image](https://github.com/user-attachments/assets/54e77e41-6eb1-438c-8b3b-9045fb72f4a3)
<br><br>
### 상호 작용 이벤트 제어 대상 구분 불가 현상
![image](https://github.com/user-attachments/assets/ebc79183-2d1e-4834-a0cc-4f53e6e205e7)  
<br><br>
하나의 오브젝트를 2개의 발판으로 제어하기 위해 초기에는 static Action 변수 사용 
플레이어의 수를 체크하는 방식으로 문제를 해결, 하지만 이로 인해 다른 문제가 발생.
<br><br>
![image](https://github.com/user-attachments/assets/8e9c2cfb-b8dc-4787-bc3f-3b6345e0b129)
<br><br>
발판으로 제어해야 할 오브젝트가 2개 이상이어도 static을 사용했기 때문에 제어 대상 구분 없이 모든 발판에서 이벤트가 발생해, 정확한 오브젝트의 제어가 되지 않음
<br><br>
![image](https://github.com/user-attachments/assets/488cfb27-132b-42b6-84a7-47f95b6c04b6)
<br>
제어될 오브젝트와 연결되는 상호 작용 오브젝트와 제어 규칙을 담는 구조체를 만들어 리스트로 생성  
상호 작용 On/Off를 체크할 Action 변수를 상호 작용 오브젝트 최상위 클래스에 만들어준 뒤 CheckEvent 메서드를 등록해주면 온/오프가 될 때마다 모든 조건이 충족 되었는지 체크하여 오브젝트를 제어하는 것으로 문제를 해결  

## 🎥 시연 영상
<br><br>
▼ **시연 영상 바로가기**  
[<img width="635" alt="얼불썸네일" src="https://github.com/user-attachments/assets/cd19bc75-9904-4bc0-85b9-422255fcb66a" />](https://youtu.be/yp8Ek9Y3mfo)

<br><br>

