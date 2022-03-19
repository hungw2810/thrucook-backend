USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S011_20211201_#127-clinic-permission');

-- table `employees` new columns: `role_id`, `is_enabled`
ALTER TABLE `drcloud_main`.`employees` 
ADD COLUMN role_id char(36) NOT NULL AFTER `user_id`;

ALTER TABLE `drcloud_main`.`employees` 
ADD COLUMN is_enabled TINYINT(1) NOT NULL DEFAULT 1 AFTER `role_id`;

-- New tables	
CREATE TABLE 	permission_types		(
	permission_type_id int NOT NULL, PRIMARY KEY(`permission_type_id`),		
	permission_type_name varchar(128) NOT NULL		
			);
			
CREATE TABLE 	api_action_types		(
	api_action_type_id int NOT NULL, PRIMARY KEY(`api_action_type_id`),		
	api_action_type_name varchar(128) NOT NULL		
			);
			
CREATE TABLE 	api_method_types		(
	api_method_type_id int NOT NULL, PRIMARY KEY(`api_method_type_id`),		
	api_method_type_name varchar(128) NOT NULL		
			);
			
CREATE TABLE 	api_services		(
	api_service_id int NOT NULL, PRIMARY KEY(`api_service_id`),		
	api_service_name varchar(128) NOT NULL		
			);
			
CREATE TABLE 	apis		(
	api_id int NOT NULL, PRIMARY KEY(`api_id`),		
	api_name varchar(128) NOT NULL,		
	api_service_id int NOT NULL, FOREIGN KEY (api_service_id) REFERENCES api_services(api_service_id),		
	api_method_type_id int NOT NULL, FOREIGN KEY (api_method_type_id) REFERENCES api_method_types(api_method_type_id),		
	api_route varchar(1024) NOT NULL,		
	api_action_type_id int NOT NULL, FOREIGN KEY (api_action_type_id) REFERENCES api_action_types(api_action_type_id),		
	default_permission_type_id int NOT NULL, FOREIGN KEY (default_permission_type_id) REFERENCES permission_types(permission_type_id)		
			);
			
CREATE TABLE 	frontend_screens		(
	frontend_screen_id int NOT NULL, PRIMARY KEY(`frontend_screen_id`),		
	frontend_screen_name varchar(256) NOT NULL		
			);
			
CREATE TABLE 	frontend_screen_api_mapping		(
	api_id int NOT NULL, FOREIGN KEY (api_id) REFERENCES apis(api_id),		
	frontend_screen_id int NOT NULL, FOREIGN KEY (frontend_screen_id) REFERENCES frontend_screens(frontend_screen_id),		
	  PRIMARY KEY(`api_id`, `frontend_screen_id`)		
			);
			
CREATE TABLE 	role_types		(
	role_type_id int NOT NULL, PRIMARY KEY(`role_type_id`),		
	role_type_name varchar(256) NOT NULL		
			);
			
			
CREATE TABLE 	standard_roles		(
	role_id int NOT NULL, PRIMARY KEY(`role_id`),		
	role_name varchar(256) NOT NULL,		
	role_type_id int NOT NULL		
			);
			
CREATE TABLE 	standard_screen_permissions		(
	standard_screen_permission_id int NOT NULL, PRIMARY KEY(`standard_screen_permission_id`),		
	standard_role_id int NOT NULL, FOREIGN KEY (standard_role_id) REFERENCES standard_roles(role_id),		
	frontend_screen_id int NOT NULL, FOREIGN KEY (frontend_screen_id) REFERENCES frontend_screens(frontend_screen_id),		
	permission_type_id int NOT NULL, FOREIGN KEY (permission_type_id) REFERENCES permission_types(permission_type_id),		
	is_editable tinyint(1) NOT NULL
			);
			
			
CREATE TABLE 	skills		(
	skill_id int NOT NULL, PRIMARY KEY(`skill_id`),		
	skill_name varchar(128) NOT NULL		
			);
			
CREATE TABLE 	frontend_features		(
	frontend_feature_id int NOT NULL, PRIMARY KEY(`frontend_feature_id`),		
	frontend_feature_name varchar(256) NOT NULL		
			);
			
CREATE TABLE 	frontend_feature_api_mapping		(
	frontend_feature_id int NOT NULL, FOREIGN KEY (frontend_feature_id) REFERENCES frontend_features(frontend_feature_id),		
	api_id int NOT NULL, FOREIGN KEY (api_id) REFERENCES apis(api_id),		
	  PRIMARY KEY(`api_id`, `frontend_feature_id`)		
			);
			
CREATE TABLE 	frontend_feature_skill_mapping		(
	frontend_feature_id int NOT NULL, FOREIGN KEY (frontend_feature_id) REFERENCES frontend_features(frontend_feature_id),		
	skill_id int NOT NULL, FOREIGN KEY (skill_id) REFERENCES skills(skill_id),		
	  PRIMARY KEY(`skill_id`, `frontend_feature_id`)		
			);
			
			
CREATE TABLE 	user_skills		(
	user_skill_id char(36) NOT NULL, PRIMARY KEY(`user_skill_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	user_id char(36) NOT NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	skill_id int NOT NULL		
			);
			
CREATE TABLE 	roles		(
	role_id char(36) NOT NULL, PRIMARY KEY(`role_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	role_type_id int NOT NULL,		
	copy_from_standard_role_id int NULL,		
	role_name varchar(256) NOT NULL,		
	is_enabled tinyint(1) NOT NULL DEFAULT 1,
	is_deleted tinyint(1) NOT NULL DEFAULT 0,
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	screen_permissions		(
	screen_permission_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`screen_permission_id`),
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	role_id char(36) NOT NULL, FOREIGN KEY (role_id) REFERENCES roles(role_id),		
	frontend_screen_id int NOT NULL,		
	permission_type_id int NOT NULL,		
	is_editable tinyint(1) NOT NULL		
	 		);
	 		
CREATE TABLE 	user_groups		(
	user_group_id char(36) NOT NULL, PRIMARY KEY(`user_group_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	user_group_name varchar(256) NOT NULL,		
	is_all_locations tinyint(1) NOT NULL DEFAULT 0,		
	is_all_doctors tinyint(1) NOT NULL DEFAULT 0,		
	is_enabled tinyint(1) NOT NULL DEFAULT 1,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	user_group_location_mapping		(
	user_group_id char(36) NOT NULL, FOREIGN KEY (user_group_id) REFERENCES user_groups(user_group_id),		
	location_id char(36) NOT NULL, FOREIGN KEY (location_id) REFERENCES locations(location_id),		
	  PRIMARY KEY(`user_group_id`, `location_id`)		
			);
			
CREATE TABLE 	user_group_doctor_mapping		(
	user_group_id char(36) NOT NULL, FOREIGN KEY (user_group_id) REFERENCES user_groups(user_group_id),		
	doctor_id char(36) NOT NULL, FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id),		
	  PRIMARY KEY(`user_group_id`, `doctor_id`)		
			);
			
CREATE TABLE 	user_group_user_mapping		(
	user_group_id char(36) NOT NULL, FOREIGN KEY (user_group_id) REFERENCES user_groups(user_group_id),		
	user_id char(36) NOT NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	  PRIMARY KEY(`user_group_id`, `user_id`)		
			);

-- Index
ALTER TABLE `drcloud_main`.`roles` ADD FULLTEXT `role_name_idx`(`role_name`);
ALTER TABLE `drcloud_main`.`user_groups` ADD FULLTEXT `user_group_name_idx`(`user_group_name`);
			
-- Init data
INSERT INTO `drcloud_main`.`api_method_types` (`api_method_type_id`, `api_method_type_name`) VALUES ('1', 'GET');
INSERT INTO `drcloud_main`.`api_method_types` (`api_method_type_id`, `api_method_type_name`) VALUES ('2', 'POST');
INSERT INTO `drcloud_main`.`api_method_types` (`api_method_type_id`, `api_method_type_name`) VALUES ('3', 'PUT');
INSERT INTO `drcloud_main`.`api_method_types` (`api_method_type_id`, `api_method_type_name`) VALUES ('4', 'DELETE');

INSERT INTO `drcloud_main`.`api_action_types` (`api_action_type_id`, `api_action_type_name`) VALUES ('10', 'Get');
INSERT INTO `drcloud_main`.`api_action_types` (`api_action_type_id`, `api_action_type_name`) VALUES ('20', 'Set');

INSERT INTO `drcloud_main`.`api_services` (`api_service_id`, `api_service_name`) VALUES ('1', 'Main');

INSERT INTO `drcloud_main`.`permission_types` (`permission_type_id`, `permission_type_name`) VALUES ('0', 'None');
INSERT INTO `drcloud_main`.`permission_types` (`permission_type_id`, `permission_type_name`) VALUES ('10', 'Read');
INSERT INTO `drcloud_main`.`permission_types` (`permission_type_id`, `permission_type_name`) VALUES ('20', 'Write');

INSERT INTO `drcloud_main`.`role_types` (`role_type_id`, `role_type_name`) VALUES ('10', 'Owner');
INSERT INTO `drcloud_main`.`role_types` (`role_type_id`, `role_type_name`) VALUES ('20', 'Admin');
INSERT INTO `drcloud_main`.`role_types` (`role_type_id`, `role_type_name`) VALUES ('30', 'User defined');

INSERT INTO `drcloud_main`.`skills` (`skill_id`, `skill_name`) VALUES ('1', 'Receptionist');
INSERT INTO `drcloud_main`.`skills` (`skill_id`, `skill_name`) VALUES ('2', 'Assistant');
INSERT INTO `drcloud_main`.`skills` (`skill_id`, `skill_name`) VALUES ('3', 'Doctor');

INSERT INTO `drcloud_main`.`frontend_features` (`frontend_feature_id`, `frontend_feature_name`) VALUES ('101', 'Add appointment');
INSERT INTO `drcloud_main`.`frontend_features` (`frontend_feature_id`, `frontend_feature_name`) VALUES ('102', 'Approve appointment');
INSERT INTO `drcloud_main`.`frontend_features` (`frontend_feature_id`, `frontend_feature_name`) VALUES ('103', 'Check in appointment');
INSERT INTO `drcloud_main`.`frontend_features` (`frontend_feature_id`, `frontend_feature_name`) VALUES ('104', 'Start/finish appointment');
INSERT INTO `drcloud_main`.`frontend_features` (`frontend_feature_id`, `frontend_feature_name`) VALUES ('105', 'Cancel appointment');

INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('1', 'Clinic Settings - General');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('2', 'Clinic Settings - Locations');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('3', 'Clinic Settings - Specialties');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('4', 'Clinic Settings - Doctors');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('5', 'Clinic Settings - Symptoms');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('6', 'Clinic Settings - Users');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('7', 'Clinic Settings - User Roles');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('8', 'Clinic Settings - User Groups');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('9', 'Dashboards - Doctor Schedule');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('10', 'Dashboards - Appointments');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('11', 'Dashboards - Today Queue');

INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('101', '1');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('102', '1');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('103', '1');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('105', '1');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('104', '2');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('102', '3');
INSERT INTO `drcloud_main`.`frontend_feature_skill_mapping` (`frontend_feature_id`, `skill_id`) VALUES ('104', '3');

INSERT INTO `drcloud_main`.`standard_roles` (`role_id`, `role_name`, `role_type_id`) VALUES ('1', 'Owner', '10');
INSERT INTO `drcloud_main`.`standard_roles` (`role_id`, `role_name`, `role_type_id`) VALUES ('2', 'Administrator', '20');
INSERT INTO `drcloud_main`.`standard_roles` (`role_id`, `role_name`, `role_type_id`) VALUES ('3', 'Default User', '30');

INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (1,1,1,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (2,1,2,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (3,1,3,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (4,1,4,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (5,1,5,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (6,1,6,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (7,1,7,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (8,1,8,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (9,1,9,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (10,1,10,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (11,1,11,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (12,2,1,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (13,2,2,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (14,2,3,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (15,2,4,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (16,2,5,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (17,2,6,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (18,2,7,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (19,2,8,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (20,2,9,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (21,2,10,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (22,2,11,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (23,3,1,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (24,3,2,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (25,3,3,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (26,3,4,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (27,3,5,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (28,3,6,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (29,3,7,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (30,3,8,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (31,3,9,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (32,3,10,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (33,3,11,20,1);

-- Migrate data
INSERT INTO `drcloud_main`.`roles`(`role_id`,`clinic_id`,`role_type_id`,`copy_from_standard_role_id`, `role_name`,`is_deleted`)
SELECT uuid_v4(), c.clinic_id, r.role_type_id, r.role_id, r.role_name, 0 as is_deleted FROM
(SELECT * FROM `drcloud_main`.`clinics` WHERE is_deleted = 0) AS c
JOIN `drcloud_main`.`standard_roles` AS r;

INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`,`role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, sp.frontend_screen_id, sp.permission_type_id, sp.is_editable 
FROM `drcloud_main`.`roles` AS r
JOIN `drcloud_main`.`standard_roles` AS sr ON sr.role_id = r.copy_from_standard_role_id
JOIN `drcloud_main`.`standard_screen_permissions` AS sp ON sp.standard_role_id = sr.role_id;

UPDATE `drcloud_main`.`employees` as e
JOIN (SELECT * FROM `drcloud_main`.`clinics` WHERE is_deleted = 0) as c ON c.clinic_id=e.clinic_id && c.clinic_owner_user_id=e.user_id
JOIN (SELECT * FROM `drcloud_main`.`roles` WHERE role_type_id=10) as r ON r.clinic_id=e.clinic_id
SET e.role_id = r.role_id;
