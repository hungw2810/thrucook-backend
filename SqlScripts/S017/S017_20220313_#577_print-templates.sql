USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S017_20220313_#577_print-templates');

INSERT INTO `drcloud_main`.`physical_file_types` (`physical_file_type_id`, `physical_file_type_name`) VALUES ('2', 'Print Template');

INSERT INTO `drcloud_main`.`physical_files`(`physical_file_type_id`,`physical_file_status_id`,`file_length_in_bytes`,`s3_bucket_id`,`s3_file_key`,`physical_file_name`,`physical_file_extension`)
VALUES (2,1,0,1,'print-templates/1.docx','1.docx','docx');

CREATE TABLE 	print_templates		(
	print_template_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`print_template_id`),		
	print_template_name varchar(256) NOT NULL,		
	print_template_file_id bigint NULL, FOREIGN KEY (print_template_file_id) REFERENCES physical_files(physical_file_id),		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
INSERT INTO `drcloud_main`.`print_templates`(`print_template_name``print_template_file_id`)
VALUES ('Phiếu siêu âm tổng quát',0);

ALTER TABLE `drcloud_main`.`clinic_print_template_mapping` 
ADD INDEX `clinic_print_template_mapping_ibfk_2_idx` (`clinic_id` ASC) VISIBLE;
;
ALTER TABLE `drcloud_main`.`clinic_print_template_mapping` 
ADD CONSTRAINT `clinic_print_template_mapping_ibfk_1`
  FOREIGN KEY (`print_template_id`)
  REFERENCES `drcloud_main`.`print_templates` (`print_template_id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `clinic_print_template_mapping_ibfk_2`
  FOREIGN KEY (`clinic_id`)
  REFERENCES `drcloud_main`.`clinics` (`clinic_id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;
