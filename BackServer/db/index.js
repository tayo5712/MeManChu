const mysql = require("mysql2/promise");

const pool = mysql.createPool({
	// aws ip
	host: "j8c210.p.ssafy.io",
	// mysql username
	user: "unity",
	// mysql user password
	password: "unityisbacon",
	// db name
	database: "unityInfo",
	waitForConnections: true,
	connectionLimit: 10,
	queueLimit: 0,
});

module.exports = { pool };

