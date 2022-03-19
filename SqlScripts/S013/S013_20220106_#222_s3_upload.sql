USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S013_20220106_#222_s3_upload');

-- Enums
CREATE TABLE 	physical_file_types		(
	physical_file_type_id smallint NOT NULL, PRIMARY KEY(`physical_file_type_id`),		
	physical_file_type_name varchar(128) NOT NULL		
			);

INSERT INTO `drcloud_main`.`physical_file_types` (`physical_file_type_id`, `physical_file_type_name`) VALUES ('1', 'Avatar');

CREATE TABLE 	physical_file_status		(
	physical_file_status_id smallint NOT NULL, PRIMARY KEY(`physical_file_status_id`),		
	physical_file_status_name varchar(128) NOT NULL		
			);

INSERT INTO `drcloud_main`.`physical_file_status` (`physical_file_status_id`, `physical_file_status_name`) VALUES ('0', 'New');
INSERT INTO `drcloud_main`.`physical_file_status` (`physical_file_status_id`, `physical_file_status_name`) VALUES ('1', 'OK');
INSERT INTO `drcloud_main`.`physical_file_status` (`physical_file_status_id`, `physical_file_status_name`) VALUES ('2', 'WillBeDeleted');
INSERT INTO `drcloud_main`.`physical_file_status` (`physical_file_status_id`, `physical_file_status_name`) VALUES ('3', 'Deleted');
INSERT INTO `drcloud_main`.`physical_file_status` (`physical_file_status_id`, `physical_file_status_name`) VALUES ('4', 'Corrupted');


CREATE TABLE 	s3_buckets		(
	s3_bucket_id smallint NOT NULL, PRIMARY KEY(`s3_bucket_id`),		
	s3_bucket_name varchar(128) NOT NULL,		
	description varchar(128) NOT NULL		
			);

INSERT INTO `drcloud_main`.`s3_buckets` (`s3_bucket_id`, `s3_bucket_name`, `description`) VALUES ('1', 'drcloudvn', 'Avatar, logo');

-- PhysicalFiles
CREATE TABLE 	physical_files		(
	physical_file_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`physical_file_id`),		
	physical_file_type_id smallint NOT NULL,		
	physical_file_status_id smallint NOT NULL,		
	file_length_in_bytes bigint NOT NULL,		
	file_md5 char(36) NULL,		
	s3_bucket_id smallint NOT NULL, FOREIGN KEY (s3_bucket_id) REFERENCES s3_buckets(s3_bucket_id),		
	s3_file_key varchar(1024) NOT NULL,		
	physical_file_name varchar(256) NOT NULL,		
	physical_file_extension varchar(10) NOT NULL,		
	s3_small_thumbnail_file_key varchar(1024) NULL,		
	s3_medium_thumbnail_file_key varchar(1024) NULL,		
	s3_large_thumbnail_file_key varchar(1024) NULL,		
	is_deleted tinyint(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);

ALTER TABLE `drcloud_main`.`user_informations` 
CHANGE COLUMN `avatar_file_key` `avatar_file_id` BIGINT NULL DEFAULT NULL ,
ADD INDEX `avatar_file_id` (`avatar_file_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`user_informations` 
ADD CONSTRAINT `user_informations_ibfk_1`
  FOREIGN KEY (`avatar_file_id`)
  REFERENCES `drcloud_main`.`physical_files` (`physical_file_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `drcloud_main`.`clinics`
CHANGE COLUMN `logo_file_key` `logo_file_id` BIGINT NULL DEFAULT NULL ,
ADD INDEX `logo_file_id` (`logo_file_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`clinics` 
ADD CONSTRAINT `clinics_ibfk_2`
  FOREIGN KEY (`logo_file_id`)
  REFERENCES `drcloud_main`.`physical_files` (`physical_file_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `drcloud_main`.`clinic_patients`
CHANGE COLUMN `avatar_file_key` `avatar_file_id` BIGINT NULL DEFAULT NULL ,
ADD INDEX `avatar_file_id` (`avatar_file_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`clinic_patients` 
ADD CONSTRAINT `clinic_patients_ibfk_4`
  FOREIGN KEY (`avatar_file_id`)
  REFERENCES `drcloud_main`.`physical_files` (`physical_file_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `drcloud_main`.`patients`
CHANGE COLUMN `avatar_file_key` `avatar_file_id` BIGINT NULL DEFAULT NULL ,
ADD INDEX `avatar_file_id` (`avatar_file_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`patients` 
ADD CONSTRAINT `patients_ibfk_2`
  FOREIGN KEY (`avatar_file_id`)
  REFERENCES `drcloud_main`.`physical_files` (`physical_file_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `drcloud_main`.`doctors`
CHANGE COLUMN `avatar_file_key` `avatar_file_id` BIGINT NULL DEFAULT NULL ,
ADD INDEX `avatar_file_id` (`avatar_file_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`doctors` 
ADD CONSTRAINT `doctors_ibfk_3`
  FOREIGN KEY (`avatar_file_id`)
  REFERENCES `drcloud_main`.`physical_files` (`physical_file_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;