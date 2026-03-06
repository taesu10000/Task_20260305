
1. PostgreSQL 설치
2. 설치시 비밀번호 기억
3. 비밀번호 appsettings.json 파일의 connectionString에 입력
3. DB Initialize
비주얼 스튜디오 상단에 보기 -> 터미널 클릭
아래 명령어 입력 후 엔터
dotnet ef migrations add InitialCreate --project infrastructure --startup-project EmergencyContactManager