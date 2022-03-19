USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S014_20220112_#415_permissions');

-- employees FK
ALTER TABLE `drcloud_main`.`employees` 
ADD INDEX `role_id` (`role_id` ASC) VISIBLE;
ALTER TABLE `drcloud_main`.`employees` 
ADD CONSTRAINT `employees_ibfk_3`
  FOREIGN KEY (`role_id`)
  REFERENCES `drcloud_main`.`roles` (`role_id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

-- Merge patients
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (120,'Merge clinic patients (Auth policies: ClinicOnly)',1,2,'clinic-patients/merge',20,10,0);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (120,12);

-- new screens
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('13', 'Clinic Settings - Properties');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('14', 'Clinic Settings - Forms');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('15', 'Clinic Settings - Medicine Library');
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('16', 'Dashboards - Examination In-Progress');

-- standard permission for new screens
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (37,1,13,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (38,1,14,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (39,1,15,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (40,1,16,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (41,2,13,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (42,2,14,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (43,2,15,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (44,2,16,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (45,3,13,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (46,3,14,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (47,3,15,0,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (48,3,16,20,1);

-- migrate standard permission to clinic roles
INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`,`role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, sp.frontend_screen_id, sp.permission_type_id, sp.is_editable 
FROM `drcloud_main`.`roles` AS r
JOIN `drcloud_main`.`standard_roles` AS sr ON sr.role_id = r.copy_from_standard_role_id
JOIN (SELECT * FROM `drcloud_main`.`standard_screen_permissions` WHERE frontend_screen_id in (13,14,15,16)) AS sp ON sp.standard_role_id = sr.role_id;

-- new apis
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (121,'Search medicine library (Auth policies: ClinicOnly)',1,1,'medicines',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (122,'Add new medicine to library (Auth policies: ClinicOnly)',1,2,'medicines',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (123,'Delete medicine from library (Auth policies: ClinicOnly)',1,4,'medicines/{medicineId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (124,'Search Properties (Auth policies: ClinicOnly)',1,1,'properties',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (125,'Create new Property (Auth policies: ClinicOnly)',1,2,'properties',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (126,'Update Property (Auth policies: ClinicOnly)',1,3,'properties/{propertyId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (127,'Delete Property (Auth policies: ClinicOnly)',1,4,'properties/{propertyId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (128,'Get Detail Properties By PropertyId (Auth policies: ClinicOnly)',1,1,'properties/{propertyId}',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (129,'Get all forms (Auth policies: ClinicOnly)',1,1,'forms',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (130,'Get existing form details (Auth policies: ClinicOnly)',1,1,'forms/{formId}',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (131,'Create new form (Auth policies: ClinicOnly)',1,2,'forms',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (132,'Update existing form (Auth policies: ClinicOnly)',1,3,'forms/{formId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (133,'Delete existing form (Auth policies: ClinicOnly)',1,4,'forms/{formId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (134,'Enable existing form (Auth policies: ClinicOnly)',1,3,'forms/{formId}/set-enabled',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (135,'Update medicine (Auth policies: ClinicOnly)',1,3,'medicines/{medicineId}',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (136,'Get all result sheets by patient (Auth policies: PatientOnly)',1,1,'appointments/result-sheets',10,0,10);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (137,'Create new result-sheet (Auth policies: ClinicOnly)',1,2,'result-sheets',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (138,'Create new prescriptions (Auth policies: ClinicOnly)',1,2,'prescriptions',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (139,'Get form properties  (Auth policies: ClinicOnly)',1,1,'forms/{formId}/properties',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (140,'Get form by entityTypeId (Auth policies: ClinicOnly)',1,1,'forms/all-by-entity-type',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (141,'Get next appointment (Auth policies: ClinicOnly)',1,1,'clinic-appointments/next',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (142,'Get result sheet details of appointment (Auth policies: PatientOnly)',1,1,'appointments/{appointmentId}/result-sheet',10,0,10);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (143,'Get prescriptions of appointment (Auth policies: PatientOnly)',1,1,'appointments/{appointmentId}/prescription',10,0,10);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (144,'Mark upload done',1,3,'files​/{fileId}/upload-done',20,20,20);

-- api-screens
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (121,15);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (122,15);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (123,15);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (124,13);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (125,13);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (128,13);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (126,13);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (127,13);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (129,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (130,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (131,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (132,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (133,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (134,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (135,15);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (33,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (139,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (140,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (141,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (137,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (138,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (29,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (111,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (121,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (110,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (109,16);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (31,16);
