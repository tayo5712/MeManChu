var winstonDaily = require('winston-daily-rotate-file');


const { createLogger, format, transports } = require('winston');                                                                     // 한번에 여러개의 객체를 한번에 만든다. 모든 변수가 winston관련 모듈을 불러온다
const koreanTime = () => new Date().toLocaleString('en-US', {
    timeZone: 'Asia/Seoul',
  });

// const { combine, timestamp, printf } = format;                                                                //  format.combine,  format.timestamp,  format.printf 이런것들이 귀찮으면  상단처럼 정의하고 코드에는 format을 제외해도 된다. 지금은 format을 붙여 호출

const logger = createLogger({
     transports: [
        new (winstonDaily)({  // 로그파일 생성에 관한 설정
            name: 'info-file',
            filename: `log/%DATE%.log`,  // %DATE% 이부분이 날짜로 변경, 경로를지정,
            colorize: false,
            zippedArchive: true,
            maxSize: "20m",
            maxFiles: "1000",
            level: "info",
            format: format.combine(  // 관련설정 포멧을 설정
                format.label({ label: 'Unity Member Server' }), // 라벨을 정의(서버호스트명으로 많이사용)
                // format.colorize(), // 파일에서는 이게 있으면 색상이 변경되는게 아니고 색상의 문자열이 나타난다.
                format.timestamp({    // 시간의 형식을 정의
                    format: koreanTime
                }),
                format.printf(   // 파일안에 로그의 형식을 정의
                    //info => `{"${info.timestamp}"  "[${info.label}]"  "${info.level}"  "${info.message}"}`
                    info => `${info.timestamp} ${info.level} ${info.message}`
                )
            ),
            showlevel: true,
            json: false,
        })
        //     }),
        // new (transports.Console)({
        //     name: 'debug-console',
        //     colorize: true,
        //     level: "debug",
        //     format: format.combine(
        //             format.label({ label: 'docker-crzwas01' }),
        //             format.colorize(),
        //             format.timestamp({
        //             format: "YYYY-MM-DD HH:mm:ss"
        //         }),
        //             format.printf(
        //                 info => `{"${info.timestamp}"  "[${info.label}]"  "${info.level}"  "${info.message}"}`
        //             )
        //     ),
        //     showlevel: true,
        //     json: false,
        // })
        ]
    });

logger.stream = {    // httpd log  출력하기
    write: function(message, encoding) {
        logger.info(message); // 단순히 message를 default 포맷으로 출력
    },
};
    
module.exports = logger; 