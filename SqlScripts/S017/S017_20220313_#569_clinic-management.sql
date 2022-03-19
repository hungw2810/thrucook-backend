USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S017_20220313_#569_clinic-management');

INSERT INTO `user_types` (`user_type_id`, `user_type_name`) VALUES ('3', 'Moderator');

CREATE TABLE 	clinic_management_informations		(
	clinic_id char(36) NOT NULL, PRIMARY KEY(`clinic_id`),		
	address varchar(256) NULL,		
	contact_info varchar(256) NULL,		
	specialty varchar(256) NULL,		
	contract_info varchar(256) NULL,		
	staff_in_charge varchar(256) NULL,		
	customer_code varchar(256) NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);

CREATE TABLE 	clinic_status		(
	clinic_status_id smallint NOT NULL, PRIMARY KEY(`clinic_status_id`),		
	clinic_status_name varchar(128) NOT NULL		
			);
INSERT INTO `clinic_status` (`clinic_status_id`, `clinic_status_name`) VALUES ('1', 'Active');
INSERT INTO `clinic_status` (`clinic_status_id`, `clinic_status_name`) VALUES ('2', 'Deactivated');
INSERT INTO `clinic_status` (`clinic_status_id`, `clinic_status_name`) VALUES ('99', 'Deleted');

ALTER TABLE `drcloud_main`.`clinics`
ADD COLUMN `clinic_status_id` SMALLINT NOT NULL DEFAULT 1 AFTER `allow_booking_in_days`;
UPDATE `drcloud_main`.`clinics` SET `clinic_status_id` = 99 WHERE `is_deleted` = 1;
