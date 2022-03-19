USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S014_20220112_#414_result_sheet');

-- Common tables
CREATE TABLE 	entity_types		(
	entity_type_id smallint NOT NULL, PRIMARY KEY(`entity_type_id`),		
	entity_type_name varchar(128) NOT NULL		
			);
INSERT INTO `drcloud_main`.`entity_types` (`entity_type_id`, `entity_type_name`) VALUES ('1', 'Doctor');
INSERT INTO `drcloud_main`.`entity_types` (`entity_type_id`, `entity_type_name`) VALUES ('2', 'Clinic Patient');
INSERT INTO `drcloud_main`.`entity_types` (`entity_type_id`, `entity_type_name`) VALUES ('3', 'Result Sheet');

CREATE TABLE 	property_value_types		(
	property_value_type_id smallint NOT NULL, PRIMARY KEY(`property_value_type_id`),		
	property_value_type_name varchar(128) NOT NULL		
			);
INSERT INTO `drcloud_main`.`property_value_types` (`property_value_type_id`, `property_value_type_name`) VALUES ('1', 'Free text');
INSERT INTO `drcloud_main`.`property_value_types` (`property_value_type_id`, `property_value_type_name`) VALUES ('2', 'List of Options');
INSERT INTO `drcloud_main`.`property_value_types` (`property_value_type_id`, `property_value_type_name`) VALUES ('3', 'Date');
INSERT INTO `drcloud_main`.`property_value_types` (`property_value_type_id`, `property_value_type_name`) VALUES ('4', 'Date & Time');

CREATE TABLE 	medicine_unit_types		(
	medicine_unit_type_id smallint NOT NULL, PRIMARY KEY(`medicine_unit_type_id`),		
	medicine_unit_type_name varchar(128) NOT NULL		
			);
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('1', 'Tablet');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('2', 'Blister');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('3', 'Packet');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('4', 'Sachet');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('5', 'Tube');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('6', 'Bottle');
INSERT INTO `drcloud_main`.`medicine_unit_types` (`medicine_unit_type_id`, `medicine_unit_type_name`) VALUES ('7', 'Set');


-- Main tables
CREATE TABLE 	properties		(
	property_id char(36) NOT NULL, PRIMARY KEY(`property_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (`clinic_id`) REFERENCES `clinics`(`clinic_id`),		
	entity_type_id smallint NOT NULL,		
	property_name varchar(256) NOT NULL,		
	property_internal_name varchar(256) NOT NULL,		
	property_value_type_id smallint NOT NULL,		
	property_value_type_detail text NOT NULL,		
	is_editable tinyint(1) NOT NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);
			
CREATE TABLE 	property_values		(
	property_value_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`property_value_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	property_id char(36) NOT NULL,		
	entity_type_id smallint NOT NULL,		
	entity_uuid char(36) NULL,		
	entity_id bigint NULL,		
	value varchar(2048) NOT NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);
			
CREATE TABLE 	forms		(
	form_id char(36) NOT NULL, PRIMARY KEY(`form_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	entity_type_id smallint NOT NULL,		
	form_name varchar(256) NOT NULL,		
	is_editable tinyint(1) NOT NULL,		
	is_enabled tinyint(1) NOT NULL DEFAULT 1,
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);
			
CREATE TABLE 	form_property_mapping		(
	form_id char(36) NOT NULL, FOREIGN KEY (form_id) REFERENCES forms(form_id),		
	property_id char(36) NOT NULL, FOREIGN KEY (property_id) REFERENCES properties(property_id),		
	order_value int NOT NULL DEFAULT 0,		
	  PRIMARY KEY(`form_id`, `property_id`)		
);
			
CREATE TABLE 	medicines		(
	medicine_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`medicine_id`),		
	medicine_name varchar(256) NOT NULL,		
	clinic_id char(36) NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	is_editable tinyint(1) NOT NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);
ALTER TABLE medicines ADD FULLTEXT medicine_name_idx (medicine_name);
ALTER TABLE drcloud_main.medicines ADD INDEX medicine_name_normal_idx (medicine_name);

CREATE TABLE 	result_sheets		(
	result_sheet_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`result_sheet_id`),		
	appointment_id bigint NOT NULL, FOREIGN KEY (appointment_id) REFERENCES appointments(appointment_id),		
	form_id char(36) NOT NULL, FOREIGN KEY (form_id) REFERENCES forms(form_id),		
	symptom text NULL,		
	result text NULL,		
	re_examination_date datetime NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);
			
CREATE TABLE 	prescriptions		(
	prescription_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`prescription_id`),		
	appointment_id bigint NOT NULL, FOREIGN KEY (appointment_id) REFERENCES appointments(appointment_id),		
	note text NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
);

CREATE TABLE 	prescription_medicines		(
	prescription_medicine_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`prescription_medicine_id`),		
	prescription_id bigint NOT NULL, FOREIGN KEY (prescription_id) REFERENCES prescriptions(prescription_id),		
	medicine_id bigint NOT NULL,		
	medicine_name varchar(256) NOT NULL,		
	amount float NOT NULL,		
	medicine_unit_type_id smallint NOT NULL,		
	guide varchar(1024) NOT NULL		
);
