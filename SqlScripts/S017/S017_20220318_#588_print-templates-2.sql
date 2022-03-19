USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S017_20220318_#588_print-templates-2');

ALTER TABLE `drcloud_main`.`forms` 
CHANGE COLUMN `print_template_id` `print_template_id` BIGINT NULL ;

ALTER TABLE drcloud_main.properties ADD FULLTEXT property_name_idx (property_name);
