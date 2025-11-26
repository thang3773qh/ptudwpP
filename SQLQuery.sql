CREATE TABLE [dbo].[tb_Account](
[AccountId] [int] IDENTITY(1,1) NOT NULL,
[Username] [nvarchar](50) NULL,
[Password] [nvarchar](50) NULL,
[FullName] [nvarchar](50) NULL,
[Phone] [nvarchar](50) NULL,
[Email] [nvarchar](50) NULL,
[RoleId] [int] NULL,
[LastLogin] [nchar](10) NULL,
[IsActive] [bit] NOT NULL,)

CREATE TABLE [dbo].[tb_Menu](
[MenuId] [int] IDENTITY(1,1) NOT NULL,
[Title] [nvarchar](150) NULL,
[Alias] [nvarchar](150) NULL,
[Description] [nvarchar](500) NULL,
[Levels] [int] NULL,
[ParentId] [int] NULL,
[Position] [int] NULL,
[CreatedDate] [datetime] NULL,
[CreatedBy] [nvarchar](150) NULL,
[ModifiedDate] [datetime] NULL,
[ModifiedBy] [nvarchar](150) NULL,
[IsActive] [bit] NOT NULL,)

CREATE TABLE [dbo].[tb_Role](
[RoleId] [int] IDENTITY(1,1) NOT NULL,
[RoleName] [nvarchar](50) NULL,
[Description] [nvarchar](50) NULL,)

CREATE TABLE [dbo].[tb_Customer](
[CustomerId] [int] IDENTITY(1,1) NOT NULL,
[Username] [nvarchar](50) NULL,
[Password] [nvarchar](50) NULL,
[Birthday] [datetime] NULL,
[Avatar] [nvarchar](50) NULL,
[Phone] [nvarchar](50) NULL,
[Email] [nvarchar](50) NULL,
[LocationId] [int] NULL,
[LastLogin] [datetime] NULL,
[IsActive] [bit] NOT NULL,)

INSERT INTO [dbo].[tb_Menu]
(
    [Title],
    [Alias],
    [Description],
    [Levels],
    [ParentId],
    [Position],
    [CreatedDate],
    [CreatedBy],
    [ModifiedDate],
    [ModifiedBy],
    [IsActive]
)
VALUES
(N'Trang chủ', N'/', N'Liên kết đến trang chủ', 1, NULL, 1, GETDATE(), N'Admin', NULL, NULL, 1),
(N'Giới thiệu', N'/About', N'Thông tin về trung tâm', 1, NULL, 2, GETDATE(), N'Admin', NULL, NULL, 1),
(N'Khóa học', N'/Courses', N'Danh sách các khóa học', 1, NULL, 3, GETDATE(), N'Admin', NULL, NULL, 1),
(N'Giảng viên', N'/Trainers', N'Thông tin đội ngũ giảng viên', 1, NULL, 4, GETDATE(), N'Admin', NULL, NULL, 1),
(N'Sự kiện', N'/Events', N'Tin tức và sự kiện của trung tâm', 1, NULL, 5, GETDATE(), N'Admin', NULL, NULL, 1),
(N'Liên hệ', N'/Contact', N'Thông tin liên hệ trung tâm', 1, NULL, 6, GETDATE(), N'Admin', NULL, NULL, 1);


CREATE TABLE [dbo].[tb_Trainers] (
    [TrainerId]   INT IDENTITY(1,1) PRIMARY KEY,
    [FullName]    NVARCHAR(150) NOT NULL,
    [Speciality]  NVARCHAR(150) NULL,        -- Chuyên ngành: Business, Marketing, ...
    [Description] NVARCHAR(1000) NULL,       -- Mô tả ngắn về giảng viên
    [Image]       NVARCHAR(250) NULL,        -- Đường dẫn ảnh (URL hoặc tên file)
    [Facebook]    NVARCHAR(250) NULL,
    [Twitter]     NVARCHAR(250) NULL,
    [Instagram]   NVARCHAR(250) NULL,
    [LinkedIn]    NVARCHAR(250) NULL,
    [IsActive]    BIT NOT NULL DEFAULT 1,
    [CreatedDate] DATETIME DEFAULT GETDATE()
);

INSERT INTO [dbo].[tb_Trainers]
(FullName, Speciality, Description, Image, Facebook, Instagram, LinkedIn, IsActive)
VALUES
(N'Nguyễn Thị Hương', N'Tiếng Anh giao tiếp', 
 N'Giảng viên tiếng Anh với hơn 8 năm kinh nghiệm giảng dạy giao tiếp và luyện phát âm chuẩn Mỹ.', 
 N'/images/trainers/huong.jpg', 
 N'https://facebook.com/huong.nguyen', N'https://instagram.com/huong.english', N'https://linkedin.com/in/huongnguyen', 1),

(N'Trần Minh Khoa', N'Tiếng Nhật N2-N1', 
 N'Giáo viên tiếng Nhật từng du học tại Tokyo, có chứng chỉ JLPT N1 và hơn 5 năm kinh nghiệm luyện thi.', 
 N'/images/trainers/khoa.jpg', 
 N'https://facebook.com/khoa.tran', N'https://instagram.com/khoa.nihongo', N'https://linkedin.com/in/khoatran', 1),

(N'Lê Hoàng Anh', N'Tiếng Hàn sơ cấp', 
 N'Giảng viên trẻ trung, năng động, tốt nghiệp khoa Hàn Quốc học – ĐH KHXH&NV, giảng dạy theo phương pháp giao tiếp trực quan.', 
 N'/images/trainers/hoanganh.jpg', 
 N'https://facebook.com/hoanganh.le', N'https://instagram.com/hoanganh.korean', N'https://linkedin.com/in/hoanganh', 1),

(N'Phạm Thị Mai', N'IELTS chuyên sâu', 
 N'Giảng viên IELTS 8.0, hơn 7 năm kinh nghiệm giảng dạy các khóa IELTS Advanced và Academic Writing.', 
 N'/images/trainers/mai.jpg', 
 N'https://facebook.com/mai.pham', N'https://instagram.com/mai.ielts', N'https://linkedin.com/in/maipham', 1),

(N'Đỗ Quang Dũng', N'Tiếng Trung giao tiếp', 
 N'Giảng viên tiếng Trung từng sinh sống tại Bắc Kinh, chuyên đào tạo tiếng Trung thương mại và du lịch.', 
 N'/images/trainers/dung.jpg', 
 N'https://facebook.com/dung.do', N'https://instagram.com/dung.mandarin', N'https://linkedin.com/in/dungdo', 1);

 UPDATE tb_Trainers
SET Image = '/assets/img/person/person-m-7.webp'
WHERE FullName = N'Nguyễn Thị Hương';

UPDATE tb_Trainers
SET Image = '/assets/img/person/person-f-8.webp'
WHERE FullName = N'Trần Minh Khoa';

UPDATE tb_Trainers
SET Image = '/assets/img/person/person-m-6.webp'
WHERE FullName = N'Lê Hoàng Anh';

UPDATE tb_Trainers
SET Image = '/assets/img/person/person-f-4.webp'
WHERE FullName = N'Phạm Thị Mai';

UPDATE tb_Trainers
SET Image = '/assets/img/person/person-m-12.webp'
WHERE FullName = N'Đỗ Quang Dũng';


CREATE TABLE tb_Events (
    EventId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description NVARCHAR(MAX),
    Image NVARCHAR(255),
    IsActive BIT DEFAULT 1
);

INSERT INTO tb_Events (Title, EventDate, Description, Image, IsActive)
VALUES
-- 1
(N'Hội thảo "Làm chủ kỹ năng IELTS Writing"', '2025-03-15 09:00:00',
 N'Buổi hội thảo chia sẻ phương pháp luyện viết hiệu quả từ các giảng viên IELTS 8.0+, giúp học viên nâng band điểm Writing nhanh chóng.',
 N'/assets/img/events/ielts-writing.webp', 1),

-- 2
(N'Lớp học thử "Giao tiếp tiếng Anh tự tin"', '2025-04-05 18:00:00',
 N'Lớp học thử miễn phí giúp học viên trải nghiệm phương pháp phản xạ tiếng Anh tự nhiên cùng giáo viên bản ngữ.',
 N'/assets/img/events/english-speaking.webp', 1),

-- 3
(N'Workshop "Du học Nhật Bản – Cơ hội và thách thức"', '2025-05-12 14:00:00',
 N'Buổi chia sẻ thông tin về học bổng, cuộc sống và lộ trình du học Nhật Bản cùng các cựu du học sinh.',
 N'/assets/img/events/japan-study.webp', 1),

-- 4
(N'Lễ trao chứng chỉ khóa học tiếng Hàn sơ cấp', '2025-06-20 09:30:00',
 N'Tri ân học viên đã hoàn thành khóa học tiếng Hàn sơ cấp. Sự kiện có sự tham gia của các giảng viên và nhà tài trợ học bổng.',
 N'/assets/img/events/korean-cert.webp', 1),

-- 5
(N'Hội thảo "Giao tiếp tiếng Trung trong kinh doanh"', '2025-08-10 10:00:00',
 N'Sự kiện đặc biệt dành cho học viên tiếng Trung, giới thiệu cách sử dụng tiếng Trung trong môi trường thương mại và đàm phán.',
 N'/assets/img/events/chinese-business.webp', 1),

-- 6
(N'Workshop "Phát âm chuẩn Mỹ trong 7 ngày"', '2025-09-25 19:00:00',
 N'Chương trình hướng dẫn học viên cách luyện phát âm theo giọng Mỹ chuẩn qua các hoạt động tương tác và thực hành trực tiếp.',
 N'/assets/img/events/american-pronunciation.webp', 1);

 