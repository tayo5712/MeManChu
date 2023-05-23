# 백엔드 서버 구축 단계

## 버전

- nodejs : v10.19.0
- mysql : Ver 8.0.32-0ubuntu0.20.04.2 for Linux on x86_64 ((Ubuntu))
- kernel : Linux ip-172-26-11-99 5.4.0-1018-aws #18-Ubuntu SMP Wed Jun 24 01:15:00 UTC 2020 x86_64 x86_64 x86_64 GNU/Linux

## 설치 순서

1. AWS 클라우드 구축
2. nodejs, mysql, nginx 설치
3. Let's Encrypt 설치

```
sudo apt-get install letsencrypt
```

4. 인증서 적용 및 .pem 키

```
sudo letsencrypt certonly --standalone -d "도메인"
```

5. sudo vi /etc/nginx/sites-available/default 파일 수정

```
server {
	listen 80;
	listen [::]:80;
        server_name j8c210.p.ssafy.io www.j8c210.p.ssafy.io;
	location / {

         return 301 https://j8c210.p.ssafy.io$request_uri;
	}
}
server {
        listen 443 ssl;
        server_name j8c210.p.ssafy.io;
        ssl_certificate /etc/letsencrypt/live/j8c210.p.ssafy.io/fullchain.pem; # managed by Certbot
        ssl_certificate_key /etc/letsencrypt/live/j8c210.p.ssafy.io/privkey.pem; # managed by Certbot
        include /etc/letsencrypt/options-ssl-nginx.conf; # managed by Certbot
        ssl_dhparam /etc/letsencrypt/ssl-dhparams.pem;
        location / {
                proxy_set_header Host $host;
                proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
                proxy_set_header X-Forwarded-Proto $scheme;
                proxy_set_header Upgrade $http_upgrade;
                proxy_set_header Connection "upgrade";
                proxy_set_header X-Real-IP $remote_addr;
                proxy_pass http://127.0.0.1:3060;
                proxy_redirect off;
       }
}
```

6. npm module 설치

```
npm install
```

7. mysql "dump.sql" import 하기
8. "email.js"에서 네이버 이메일 + 비밀번호 입력
9. nodejs 실행

```
nodemon index.js
```
