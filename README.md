# Unity_3D_SDO
Unity_3D Personal Assignment 6기 수강생손대오

# 프로젝트 이름

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [프로젝트 계기](#프로젝트-계기)
4. [주요기능](#주요기능)
5. [개발기간](#개발기간)


무료 저작권 출처 표시
https://sketchfab.com/3d-models/easter-eggs-ac0b0892e538449da59f2f9beb66f855
https://sketchfab.com/3d-models/maple-tree-4b27adcf92f644bdabf8ecc6c5bef399
https://sketchfab.com/3d-models/bird-nest-2d6d91a789484812b3f16f94a75d9c0b
https://sketchfab.com/3d-models/devil-fruit-from-onepiece-4fa50ef32813456fbef1672526832427
https://sketchfab.com/3d-models/delicious-red-apple-dc5a0c0c439942d58d038a10d7064c91
https://sketchfab.com/3d-models/wooden-sword-c5a459e83f5a4409a663ac0ce660831c
https://sketchfab.com/3d-models/4-colour-alchemist-potions-8012a4702dbe4322a0bfb77a46e29a5c#download
https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705

사용 패키지
2D Sprite
TextMeshPro
ProBuilder
InputSystem

외부 패키지
SketchfabForUnity-v1.2.1


## 👨‍🏫 프로젝트 소개
스토리 : 입구가 하나인 방. 입구는 불이 있어 나갈 수 없다. 점프패드와 움직이는 플랫폼, 장애물, 사다리를 타고 정상에 도달해 보상을 얻고 보상을 섭취하여 밖으로 나가자. + 알을 부화시켜 따라다니는 펫을 키우자.
미완성입니다.
1층에 상호작용 아이템을 배치 했고, 노란색 동그란 패드같은것을 밟으면 2층으로 갈 수 있습니다. 2층에는 움직이는 플랫폼이 있습니다. 이를 통해 3층에 갈 수 있습니다.

## 팀소개
개인과제

## 프로젝트 계기
한 10년정도 공부만 한 것 같습니다. 마이너하게 얇고 길게 가려고 회전체동역학연구실에서 석사하다가 이왕 사는거 하고 싶은거 해야하지 않나해서 다른 연구실로 컨택해서 갔습니다. 아.. 그런데 거기는 영어를 잘해야하는 곳이 였습니다. 그래서 연구원으로 좀 있다가 나와서 취업준비를 했습니다. 하.. 졸업하고 한 2년 버려서 그런건지 시기도 참 안맞고, 주변 친구들 스펙보다 더 좋은 상태였는데 시기가 참 꼬여버렸습니다. 그렇게 취업하려는데 잘 안된지 2년차, 너무 기생하고 있는 것 같아 아르바이트를 했는데, 나이먹고 치킨튀기니까 참 거시기했습니다. 비전공자지만 1인 개발쪽으로 공부해서 작품을 남기고 싶어 시작하게 되었습니다. 근데 쉽지않네요...
최대한 확장가능성과 단일책임원칙을 지키고자 제 나름 고민을 많이 했습니다. 하지만 잘 모르겠군요.

이동 - ws
시점(상하) - Mouse
시점(좌우) - ad
점프 - space Bar
상호작용 - E
아이템창 - I
아이템 창에서 조작 - 유니티UI

## 💜 주요기능

- 기능 1 입력시스템
    Generate C# Class를 사용, UI쪽 접근시, Action Maps를 스위칭하여 조작을 다르게 적용
- 기능 2
    기존 강의에서 UI에서 체력, 허기짐, 스태미나를 연산하는 부분에서 UI의 단일책임원칙을 고려하여 UI는 결과값만 노출하게 수정 & 플레이어 내부에서 각 상태에 대한 연산하도록 세팅
- 기능 3
    코루틴을 사용하여 속도가 30초간 상승, 혹은 더블점프가 30초간 가능

  코드 관계와 관련하여 피그마로 정리했습니다.
    https://www.figma.com/board/XaY8oGyKSHqEtIgmoFWLUM/Untitled?node-id=0-1&node-type=canvas&t=GVeDlzWDmRPgjqeZ-0

## ⏲️ 개발기간
- 2024.10.23(수) ~ 2024.10.30(수)





## Trouble Shooting
