USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S003_20210730_types-and-enums');

-- user_types
CREATE TABLE 	user_types		(
	user_type_id smallint NOT NULL, PRIMARY KEY(`user_type_id`),		
	user_type_name varchar(128) NOT NULL		
			);
			
INSERT INTO `user_types` (`user_type_id`, `user_type_name`) VALUES ('0', 'Super Admin');
INSERT INTO `user_types` (`user_type_id`, `user_type_name`) VALUES ('1', 'Patient');
INSERT INTO `user_types` (`user_type_id`, `user_type_name`) VALUES ('2', 'Clinic');

-- user_confirmation_types
CREATE TABLE 	user_confirmation_types		(
	confirmation_type_id smallint NOT NULL, PRIMARY KEY(`confirmation_type_id`),		
	confirmation_type_name varchar(128) NOT NULL		
			);
INSERT INTO `user_confirmation_types` (`confirmation_type_id`, `confirmation_type_name`) VALUES ('1', 'Patient Registration');
INSERT INTO `user_confirmation_types` (`confirmation_type_id`, `confirmation_type_name`) VALUES ('2', 'Patient Password Reset');
INSERT INTO `user_confirmation_types` (`confirmation_type_id`, `confirmation_type_name`) VALUES ('3', 'Clinic User Registration');
INSERT INTO `user_confirmation_types` (`confirmation_type_id`, `confirmation_type_name`) VALUES ('4', 'Clinic User Password Reset');
INSERT INTO `user_confirmation_types` (`confirmation_type_id`, `confirmation_type_name`) VALUES ('5', 'Clinic User Invitation');

-- countries
CREATE TABLE 	countries		(
	country_id smallint NOT NULL, PRIMARY KEY(`country_id`),		
	country_name varchar(128) NOT NULL		
			);

INSERT INTO `countries` (`country_id`, `country_name`) VALUES (0, 'Unknown');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (1, 'Afghanistan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (2, 'Albania');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (3, 'Algeria');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (4, 'Andorra');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (5, 'Angola');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (6, 'Antigua and Barbuda');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (7, 'Argentina');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (8, 'Armenia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (9, 'Australia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (10, 'Austria');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (11, 'Azerbaijan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (12, 'Bahamas');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (13, 'Bahrain');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (14, 'Bangladesh');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (15, 'Barbados');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (16, 'Belarus');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (17, 'Belgium');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (18, 'Belize');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (19, 'Benin');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (20, 'Bhutan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (21, 'Bolivia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (22, 'Bosnia and Herzegovina');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (23, 'Botswana');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (24, 'Brazil');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (25, 'Brunei');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (26, 'Bulgaria');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (27, 'Burkina Faso');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (28, 'Burundi');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (29, 'Côte d\'Ivoire');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (30, 'Cabo Verde');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (31, 'Cambodia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (32, 'Cameroon');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (33, 'Canada');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (34, 'Central African Republic');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (35, 'Chad');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (36, 'Chile');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (37, 'China');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (38, 'Colombia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (39, 'Comoros');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (40, 'Congo (Congo-Brazzaville)');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (41, 'Costa Rica');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (42, 'Croatia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (43, 'Cuba');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (44, 'Cyprus');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (45, 'Czechia (Czech Republic)');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (46, 'Democratic Republic of the Congo');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (47, 'Denmark');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (48, 'Djibouti');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (49, 'Dominica');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (50, 'Dominican Republic');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (51, 'Ecuador');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (52, 'Egypt');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (53, 'El Salvador');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (54, 'Equatorial Guinea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (55, 'Eritrea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (56, 'Estonia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (57, 'Eswatini (fmr. "Swaziland")');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (58, 'Ethiopia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (59, 'Fiji');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (60, 'Finland');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (61, 'France');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (62, 'Gabon');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (63, 'Gambia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (64, 'Georgia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (65, 'Germany');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (66, 'Ghana');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (67, 'Greece');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (68, 'Grenada');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (69, 'Guatemala');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (70, 'Guinea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (71, 'Guinea-Bissau');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (72, 'Guyana');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (73, 'Haiti');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (74, 'Holy See');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (75, 'Honduras');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (76, 'Hungary');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (77, 'Iceland');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (78, 'India');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (79, 'Indonesia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (80, 'Iran');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (81, 'Iraq');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (82, 'Ireland');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (83, 'Israel');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (84, 'Italy');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (85, 'Jamaica');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (86, 'Japan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (87, 'Jordan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (88, 'Kazakhstan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (89, 'Kenya');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (90, 'Kiribati');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (91, 'Kuwait');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (92, 'Kyrgyzstan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (93, 'Laos');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (94, 'Latvia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (95, 'Lebanon');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (96, 'Lesotho');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (97, 'Liberia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (98, 'Libya');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (99, 'Liechtenstein');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (100, 'Lithuania');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (101, 'Luxembourg');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (102, 'Madagascar');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (103, 'Malawi');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (104, 'Malaysia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (105, 'Maldives');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (106, 'Mali');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (107, 'Malta');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (108, 'Marshall Islands');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (109, 'Mauritania');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (110, 'Mauritius');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (111, 'Mexico');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (112, 'Micronesia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (113, 'Moldova');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (114, 'Monaco');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (115, 'Mongolia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (116, 'Montenegro');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (117, 'Morocco');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (118, 'Mozambique');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (119, 'Myanmar (formerly Burma)');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (120, 'Namibia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (121, 'Nauru');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (122, 'Nepal');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (123, 'Netherlands');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (124, 'New Zealand');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (125, 'Nicaragua');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (126, 'Niger');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (127, 'Nigeria');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (128, 'North Korea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (129, 'North Macedonia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (130, 'Norway');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (131, 'Oman');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (132, 'Pakistan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (133, 'Palau');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (134, 'Palestine State');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (135, 'Panama');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (136, 'Papua New Guinea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (137, 'Paraguay');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (138, 'Peru');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (139, 'Philippines');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (140, 'Poland');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (141, 'Portugal');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (142, 'Qatar');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (143, 'Romania');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (144, 'Russia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (145, 'Rwanda');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (146, 'Saint Kitts and Nevis');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (147, 'Saint Lucia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (148, 'Saint Vincent and the Grenadines');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (149, 'Samoa');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (150, 'San Marino');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (151, 'Sao Tome and Principe');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (152, 'Saudi Arabia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (153, 'Senegal');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (154, 'Serbia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (155, 'Seychelles');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (156, 'Sierra Leone');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (157, 'Singapore');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (158, 'Slovakia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (159, 'Slovenia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (160, 'Solomon Islands');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (161, 'Somalia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (162, 'South Africa');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (163, 'South Korea');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (164, 'South Sudan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (165, 'Spain');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (166, 'Sri Lanka');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (167, 'Sudan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (168, 'Suriname');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (169, 'Sweden');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (170, 'Switzerland');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (171, 'Syria');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (172, 'Tajikistan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (173, 'Tanzania');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (174, 'Thailand');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (175, 'Timor-Leste');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (176, 'Togo');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (177, 'Tonga');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (178, 'Trinidad and Tobago');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (179, 'Tunisia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (180, 'Turkey');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (181, 'Turkmenistan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (182, 'Tuvalu');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (183, 'Uganda');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (184, 'Ukraine');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (185, 'United Arab Emirates');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (186, 'United Kingdom');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (187, 'United States of America');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (188, 'Uruguay');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (189, 'Uzbekistan');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (190, 'Vanuatu');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (191, 'Venezuela');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (192, 'Vietnam');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (193, 'Yemen');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (194, 'Zambia');
INSERT INTO `countries` (`country_id`, `country_name`) VALUES (195, 'Zimbabwe');

-- cities			
CREATE TABLE 	cities		(
	city_id smallint NOT NULL, PRIMARY KEY(`city_id`),		
	country_id smallint NOT NULL,		
	city_name varchar(128) NOT NULL		
			);
            
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (1, 192,'An Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (2, 192,'Bà Rịa – Vũng Tàu');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (3, 192,'Bắc Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (4, 192,'Bắc Kạn');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (5, 192,'Bạc Liêu');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (6, 192,'Bắc Ninh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (7, 192,'Bến Tre');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (8, 192,'Bình Định');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (9, 192,'Bình Dương');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (10, 192,'Bình Phước');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (11, 192,'Bình Thuận');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (12, 192,'Cà Mau');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (13, 192,'Cần Thơ');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (14, 192,'Cao Bằng');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (15, 192,'Đà Nẵng');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (16, 192,'Đắk Lắk');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (17, 192,'Đắk Nông');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (18, 192,'Điện Biên');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (19, 192,'Đồng Nai');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (20, 192,'Đồng Tháp');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (21, 192,'Gia Lai');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (22, 192,'Hà Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (23, 192,'Hà Nam');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (24, 192,'Hà Nội');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (25, 192,'Hà Tĩnh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (26, 192,'Hải Dương');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (27, 192,'Hải Phòng');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (28, 192,'Hậu Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (29, 192,'Hòa Bình');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (30, 192,'Hưng Yên');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (31, 192,'Khánh Hòa');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (32, 192,'Kiên Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (33, 192,'Kon Tum');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (34, 192,'Lai Châu');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (35, 192,'Lâm Đồng');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (36, 192,'Lạng Sơn');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (37, 192,'Lào Cai');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (38, 192,'Long An');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (39, 192,'Nam Định');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (40, 192,'Nghệ An');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (41, 192,'Ninh Bình');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (42, 192,'Ninh Thuận');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (43, 192,'Phú Thọ');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (44, 192,'Phú Yên');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (45, 192,'Quảng Bình');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (46, 192,'Quảng Nam');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (47, 192,'Quảng Ngãi');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (48, 192,'Quảng Ninh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (49, 192,'Quảng Trị');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (50, 192,'Sóc Trăng');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (51, 192,'Sơn La');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (52, 192,'Tây Ninh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (53, 192,'Thái Bình');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (54, 192,'Thái Nguyên');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (55, 192,'Thanh Hóa');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (56, 192,'Thừa Thiên Huế');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (57, 192,'Tiền Giang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (58, 192,'TP Hồ Chí Minh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (59, 192,'Trà Vinh');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (60, 192,'Tuyên Quang');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (61, 192,'Vĩnh Long');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (62, 192,'Vĩnh Phúc');
INSERT INTO `cities` (`city_id`,`country_id`, `city_name`) VALUES (63, 192,'Yên Bái');

-- appointment_status
CREATE TABLE 	appointment_status		(
	appointment_status_id smallint NOT NULL, PRIMARY KEY(`appointment_status_id`),		
	appointment_status_name varchar(128) NOT NULL		
			);

INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('1000', 'NotApproved');
INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('2000', 'Approved');
INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('3000', 'CheckedIn');
INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('4000', 'InProgress');
INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('9000', 'Finished');
INSERT INTO `appointment_status` (`appointment_status_id`, `appointment_status_name`) VALUES ('9999', 'Canceled');

-- user_status
CREATE TABLE 	user_status		(
	user_status_id smallint NOT NULL, PRIMARY KEY(`user_status_id`),		
	user_status_name varchar(128) NOT NULL		
			);

INSERT INTO `user_status` (`user_status_id`, `user_status_name`) VALUES ('500', 'WaitForVerify');
INSERT INTO `user_status` (`user_status_id`, `user_status_name`) VALUES ('1000', 'Normal');

CREATE TABLE 	languages		(
	language_id tinyint NOT NULL, PRIMARY KEY(`language_id`),		
	language_name varchar(128) NOT NULL		
			);

INSERT INTO `languages` (`language_id`, `language_name`) VALUES ('1', 'English');
INSERT INTO `languages` (`language_id`, `language_name`) VALUES ('2', 'Vietnamese');