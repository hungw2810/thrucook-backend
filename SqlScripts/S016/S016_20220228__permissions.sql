USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S016_20220228__permissions');

-- new screens
UPDATE `drcloud_main`.`frontend_screens` SET `frontend_screen_name` = 'Dashboards - Today Examinations' WHERE (`frontend_screen_id` = 11);
UPDATE `drcloud_main`.`frontend_screens` SET `frontend_screen_name` = 'Lists - Contacts' WHERE (`frontend_screen_id` = 12);
INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`,`frontend_screen_name`) VALUES (17, 'Lists - Medical Records');

-- standard permission for new screens
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (49,1,17,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (50,2,17,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (51,3,17,20,1);

-- migrate standard permission to clinic roles
INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`,`role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, sp.frontend_screen_id, sp.permission_type_id, sp.is_editable 
FROM `drcloud_main`.`roles` AS r
JOIN `drcloud_main`.`standard_roles` AS sr ON sr.role_id = r.copy_from_standard_role_id
JOIN (SELECT * FROM `drcloud_main`.`standard_screen_permissions` WHERE frontend_screen_id=17) AS sp ON sp.standard_role_id = sr.role_id;

-- New APIs
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (145,'Get all result sheets by clinic patient (Auth policies: ClinicOnly)',1,1,'clinic-appointments/result-sheets',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (146,'Get result sheet details of clinic appointment (Auth policies: ClinicOnly)',1,1,'clinic-appointments/{appointmentId}/result-sheet',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (147,'Get prescriptions of clinic appointment (Auth policies: ClinicOnly)',1,1,'clinic-appointments/{appointmentId}/prescription',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (148,'Get print templates of clinic (Auth policies: ClinicOnly)',1,1,'clinics/print-templates',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (149,'Get upcoming (before checked-in) appointments  (Auth policies: ClinicOnly)',1,1,'clinic-appointments/upcoming',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (150,'Assign doctor to unapproved appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/{appointmentId}/assign-doctor',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (151,'Get medical information of clinic appointment (Auth policies: ClinicOnly)',1,1,'​clinic-appointments​/{appointmentId}/medical',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (152,'Get medical information of clinic patient (Auth policies: ClinicOnly)',1,1,'clinic-patients​/{clinicPatientId}/medical',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (153,'Update medical information of clinic patient (Auth policies: ClinicOnly)',1,3,'clinic-patients​/{clinicPatientId}/medical',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (154,'Search medical records of the clinic with paging (Auth policies: ClinicOnly)',1,2,'clinic-patients​/search-medical-records',10,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (155,'Get appointment history by patient-v2 (Auth policies: ClinicOnly)',1,1,'clinic-appointments/get-by-patient-v2',10,0,0);

-- api-screens
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (148,14);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (149,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (150,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (33,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (139,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (140,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (141,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (137,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (138,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (121,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (145,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (146,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (147,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (38,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (39,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (112,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (145,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (146,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (147,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (151,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (152,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (153,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (154,17);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (155,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (155,12);
