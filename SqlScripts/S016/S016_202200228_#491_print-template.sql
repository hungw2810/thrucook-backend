USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S016_202200228_#491_print-template');

CREATE TABLE 	clinic_print_template_mapping		(
	print_template_id bigint NOT NULL,		
	clinic_id char(36) NOT NULL,		
	PRIMARY KEY(`print_template_id`, `clinic_id`)		
);

ALTER TABLE `drcloud_main`.`forms` 
ADD COLUMN `print_template_id` BIGINT NOT NULL DEFAULT 1 AFTER `is_deleted`;