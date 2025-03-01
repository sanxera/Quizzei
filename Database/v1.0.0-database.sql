-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- QUIZZEI.dbo.COURSE definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.COURSE;

CREATE TABLE QUIZZEI.dbo.COURSE (
	COURSE_ID int NOT NULL,
	DESCRIPTION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT int NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_COURSE PRIMARY KEY (COURSE_ID)
);


-- QUIZZEI.dbo.PERMISSION definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.PERMISSION;

CREATE TABLE QUIZZEI.dbo.PERMISSION (
	PERMISSION_ID int NOT NULL,
	DESCRIPTION varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_PERMISSION PRIMARY KEY (PERMISSION_ID)
);


-- QUIZZEI.dbo.QUIZ_CATEGORY definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUIZ_CATEGORY;

CREATE TABLE QUIZZEI.dbo.QUIZ_CATEGORY (
	CATEGORY_ID int NOT NULL,
	DESCRIPTION varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUIZ_CATEGORY PRIMARY KEY (CATEGORY_ID)
);


-- QUIZZEI.dbo.QUIZ_STATUS definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUIZ_STATUS;

CREATE TABLE QUIZZEI.dbo.QUIZ_STATUS (
	QUIZ_STATUS_ID int NOT NULL,
	DESCRIPTION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUIZ_STATUS PRIMARY KEY (QUIZ_STATUS_ID)
);


-- QUIZZEI.dbo.PROFILE definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.PROFILE;

CREATE TABLE QUIZZEI.dbo.PROFILE (
	PROFILE_ID int NOT NULL,
	DESCRIPTION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE bit NOT NULL,
	PERMISSION_ID int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_PROFILE PRIMARY KEY (PROFILE_ID),
	CONSTRAINT FK_PERMISSION_ID FOREIGN KEY (PERMISSION_ID) REFERENCES QUIZZEI.dbo.PERMISSION(PERMISSION_ID)
);


-- QUIZZEI.dbo.QUIZ definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUIZ;

CREATE TABLE QUIZZEI.dbo.QUIZ (
	QUIZ_UUID uniqueidentifier NOT NULL,
	TITLE varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DESCRIPTION varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	POINTS int NOT NULL,
	CATEGORY_ID int NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUIZ PRIMARY KEY (QUIZ_UUID),
	CONSTRAINT FK_CATEGORY_ID FOREIGN KEY (CATEGORY_ID) REFERENCES QUIZZEI.dbo.QUIZ_CATEGORY(CATEGORY_ID)
);


-- QUIZZEI.dbo.[USER] definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.[USER];

CREATE TABLE QUIZZEI.dbo.[USER] (
	USER_UUID uniqueidentifier NOT NULL,
	NAME varchar(80) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	EMAIL varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PASSWORD varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ACTIVE bit NOT NULL,
	PROFILE_ID int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_USER PRIMARY KEY (USER_UUID),
	CONSTRAINT FK_PROFILE_ID FOREIGN KEY (PROFILE_ID) REFERENCES QUIZZEI.dbo.PROFILE(PROFILE_ID)
);


-- QUIZZEI.dbo.CLASSROOM definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.CLASSROOM;

CREATE TABLE QUIZZEI.dbo.CLASSROOM (
	CLASSROOM_UUID uniqueidentifier NOT NULL,
	DESCRIPTION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	USER_OWNER_UUID uniqueidentifier NOT NULL,
	COURSE_ID int NOT NULL,
	ACTIVE int NOT NULL,
	CREATED_AT int NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_CLASSROOM PRIMARY KEY (CLASSROOM_UUID),
	CONSTRAINT FK_COURSE_CLASSROOM FOREIGN KEY (COURSE_ID) REFERENCES QUIZZEI.dbo.COURSE(COURSE_ID),
	CONSTRAINT FK_USER_OWNER FOREIGN KEY (USER_OWNER_UUID) REFERENCES QUIZZEI.dbo.[USER](USER_UUID)
);


-- QUIZZEI.dbo.QUESTION definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUESTION;

CREATE TABLE QUIZZEI.dbo.QUESTION (
	QUESTION_UUID uniqueidentifier NOT NULL,
	DESCRIPTION varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	QUIZ_UUID uniqueidentifier NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUESTION PRIMARY KEY (QUESTION_UUID),
	CONSTRAINT FK_QUIZ_QUESTION_UUID FOREIGN KEY (QUIZ_UUID) REFERENCES QUIZZEI.dbo.QUIZ(QUIZ_UUID)
);


-- QUIZZEI.dbo.QUESTION_OPTION definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUESTION_OPTION;

CREATE TABLE QUIZZEI.dbo.QUESTION_OPTION (
	QUESTION_OPTIONS_UUID uniqueidentifier NOT NULL,
	DESCRIPTION varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ISCORRECT bit NOT NULL,
	QUESTION_UUID uniqueidentifier NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUESTION_OPTION PRIMARY KEY (QUESTION_OPTIONS_UUID),
	CONSTRAINT FK_QUESTION_QUESTION_OPTION_UUID FOREIGN KEY (QUESTION_UUID) REFERENCES QUIZZEI.dbo.QUESTION(QUESTION_UUID)
);


-- QUIZZEI.dbo.QUIZ_PROCESS definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.QUIZ_PROCESS;

CREATE TABLE QUIZZEI.dbo.QUIZ_PROCESS (
	QUIZ_PROCESS_UUID uniqueidentifier NOT NULL,
	QUIZ_UUID uniqueidentifier NOT NULL,
	USER_UUID uniqueidentifier NOT NULL,
	STATUS int NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_QUIZ_PROCESS PRIMARY KEY (QUIZ_PROCESS_UUID),
	CONSTRAINT FK_QUIZ_QUIZ_PROCESS_UUID FOREIGN KEY (QUIZ_UUID) REFERENCES QUIZZEI.dbo.QUIZ(QUIZ_UUID),
	CONSTRAINT FK_STATUS_QUIZ FOREIGN KEY (STATUS) REFERENCES QUIZZEI.dbo.QUIZ_STATUS(QUIZ_STATUS_ID),
	CONSTRAINT FK_USER_QUIZ_PROCESS_UUID FOREIGN KEY (USER_UUID) REFERENCES QUIZZEI.dbo.[USER](USER_UUID)
);


-- QUIZZEI.dbo.ANSWER definition

-- Drop table

-- DROP TABLE QUIZZEI.dbo.ANSWER;

CREATE TABLE QUIZZEI.dbo.ANSWER (
	ANSWER_UUID uniqueidentifier NOT NULL,
	QUESTION_OPTION_UUID uniqueidentifier NOT NULL,
	USER_UUID uniqueidentifier NOT NULL,
	CREATED_AT datetime NOT NULL,
	CREATED_BY varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_ANSWER PRIMARY KEY (ANSWER_UUID),
	CONSTRAINT FK_QUESTION_ANSWER FOREIGN KEY (QUESTION_OPTION_UUID) REFERENCES QUIZZEI.dbo.QUESTION_OPTION(QUESTION_OPTIONS_UUID),
	CONSTRAINT FK_USER_ANSWER FOREIGN KEY (USER_UUID) REFERENCES QUIZZEI.dbo.[USER](USER_UUID)
);
