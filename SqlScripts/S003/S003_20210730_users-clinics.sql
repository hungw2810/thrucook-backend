USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S003_20210730_users-clinics');

CREATE TABLE 	signup_codes		(
	signup_code_id int NOT NULL AUTO_INCREMENT, PRIMARY KEY(`signup_code_id`),		
	signup_code_value varchar(8) NOT NULL,		
	is_available bit(1) NOT NULL DEFAULT 1		
			);

CREATE TABLE 	users		(
	user_id char(36) NOT NULL, PRIMARY KEY(`user_id`),		
	user_name varchar(128) NOT NULL,		
	password_hashed varchar(1024) NOT NULL,		
	salt varchar(1024) NOT NULL,		
	user_type_id smallint NOT NULL,		
	status_id int NOT NULL DEFAULT 500,		
	provider smallint NOT NULL DEFAULT 0,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
	 		);
			
CREATE TABLE 	user_informations		(
	user_id char(36) NOT NULL, PRIMARY KEY(`user_id`),		
	first_name varchar(128) NULL,		
	last_name varchar(128) NULL,		
	email varchar(128) NULL,		
	phone_number varchar(128) NULL,		
	birthday date NULL,		
	gender smallint NULL,		
	city_id smallint NULL,
	country_id smallint NULL,		
	address varchar(256) NULL,		
	avatar_file_key varchar(256) NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	user_confirmation_codes		(
	confirmation_id char(36) NOT NULL, PRIMARY KEY(`confirmation_id`),		
	user_id char(36) NOT NULL,		
	confirmation_code varchar(128) NOT NULL,		
	confirmation_type_id smallint NOT NULL,		
	expired_time datetime NOT NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	patients		(
	patient_id char(36) NOT NULL, PRIMARY KEY(`patient_id`),		
	user_id char(36) NOT NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	patient_code varchar(128) NOT NULL,		
	patient_sequence bigint NOT NULL,
	is_default bit(1) NOT NULL,		
	avatar_file_key varchar(256) NULL,		
	full_name varchar(128) NOT NULL,		
	birthday date NOT NULL,		
	gender smallint NULL,		
	phone_number varchar(128) NOT NULL,		
	address varchar(256) NOT NULL,		
	country_id smallint NULL,		
	email varchar(128) NULL,		
	height_in_cm smallint NULL,		
	weight_in_kg smallint NULL,			
	medical_history varchar(1024) NULL,		
	allergy varchar(1024) NULL,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	clinics		(
	clinic_id char(36) NOT NULL, PRIMARY KEY(`clinic_id`),		
	clinic_name varchar(256) NOT NULL,		
	clinic_name_lower varchar(256) NOT NULL,		
	clinic_owner_user_id char(36) NOT NULL, FOREIGN KEY (clinic_owner_user_id) REFERENCES users(user_id),		
	logo_file_key varchar(256) NULL,		
	allow_booking_in_days smallint NOT NULL,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	deleted_at_utc datetime NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	employees		(
	employee_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`employee_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	user_id char(36) NOT NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
            
			
CREATE TABLE 	locations		(
	location_id char(36) NOT NULL, PRIMARY KEY(`location_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	location_name varchar(256) NOT NULL,		
	phone_number varchar(128) NOT NULL,		
	email varchar(128) NULL,		
	min_price_in_vnd double NULL,		
	max_price_in_vnd double NULL,		
	health_declaration_url varchar(1024) NULL,		
	address varchar(256) NOT NULL,		
	longitude double NOT NULL,		
	latitude double NOT NULL,		
	city_id smallint NOT NULL,		
	country_id smallint NOT NULL,		
	is_enabled bit(1) NOT NULL DEFAULT 1,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
            
CREATE TABLE 	specialties		(
	specialty_id char(36) NOT NULL, PRIMARY KEY(`specialty_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	specialty_name varchar(128) NOT NULL,		
	specialty_short_name varchar(128) NULL,		
	is_enabled bit(1) NOT NULL DEFAULT 1,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	symptoms		(
	symptom_id char(36) NOT NULL, PRIMARY KEY(`symptom_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	symptom_name varchar(128) NOT NULL,		
	content varchar(1024) NOT NULL,		
	specialty_id char(36) NULL, FOREIGN KEY (specialty_id) REFERENCES specialties(specialty_id),		
	is_enabled bit(1) NOT NULL DEFAULT 1,
	is_deleted bit(1) NOT NULL DEFAULT 0,
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);

CREATE TABLE 	doctors		(
	doctor_id char(36) NOT NULL, PRIMARY KEY(`doctor_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	specialty_id char(36) NULL, FOREIGN KEY (specialty_id) REFERENCES specialties(specialty_id),
	doctor_clinic_code varchar(128) NULL,
	doctor_code varchar(128) NOT NULL,		
	doctor_sequence bigint NOT NULL,
	doctor_name varchar(128) NOT NULL,		
	phone_number varchar(128) NULL,		
	email varchar(128) NULL,		
	avatar_file_key varchar(256) NULL,		
	years_of_experience smallint NULL,		
	introduction varchar(1024) NULL,		
	work_experience varchar(1024) NULL,		
	certificates varchar(1024) NULL,		
	is_enabled bit(1) NOT NULL DEFAULT 1,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	doctor_settings		(
	doctor_id char(36) NOT NULL, PRIMARY KEY(`doctor_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	time_per_appointment_in_minutes smallint NOT NULL DEFAULT 15,		
	buffer_time_per_appointment_in_minutes smallint NOT NULL DEFAULT 5,		
	is_visible_for_booking bit(1) NOT NULL DEFAULT 1,		
	is_auto_approve_appointment bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);

CREATE TABLE 	doctor_schedules		(
	schedule_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`schedule_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	doctor_id char(36) NOT NULL, FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id),		
	location_id char(36) NOT NULL, FOREIGN KEY (location_id) REFERENCES locations(location_id),		
	start_datetime datetime NOT NULL,		
	end_datetime datetime NOT NULL,		
	recurrence_string varchar(2048) NULL,		
	schedule_until datetime NULL,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	clinic_patients		(
	clinic_patient_id char(36) NOT NULL, PRIMARY KEY(`clinic_patient_id`),		
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	clinic_patient_code varchar(128) NOT NULL,
	clinic_patient_sequence bigint NOT NULL,
	ref_patient_id char(36) NULL, FOREIGN KEY (ref_patient_id) REFERENCES patients(patient_id),		
	ref_user_id char(36) NULL, FOREIGN KEY (ref_user_id) REFERENCES users(user_id),		
	patient_code varchar(128) NULL,		
	avatar_file_key varchar(256) NULL,		
	full_name varchar(128) NOT NULL,		
	birthday date NOT NULL,		
	gender smallint NULL,		
	phone_number varchar(128) NOT NULL,		
	address varchar(256) NOT NULL,		
	country_id smallint NULL,		
	email varchar(128) NULL,		
	height_in_cm smallint NULL,		
	weight_in_kg smallint NULL,			
	medical_history varchar(1024) NULL,		
	allergy varchar(1024) NULL,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	appointments		(
	appointment_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`appointment_id`),		
	user_id char(36) NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	patient_id char(36) NULL, FOREIGN KEY (patient_id) REFERENCES patients(patient_id),		
	clinic_patient_id char(36) NOT NULL, FOREIGN KEY (clinic_patient_id) REFERENCES clinic_patients(clinic_patient_id),
	clinic_id char(36) NOT NULL, FOREIGN KEY (clinic_id) REFERENCES clinics(clinic_id),		
	location_id char(36) NOT NULL, FOREIGN KEY (location_id) REFERENCES locations(location_id),			
	doctor_id char(36) NOT NULL, FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id),		
	schedule_id bigint NULL, FOREIGN KEY (schedule_id) REFERENCES doctor_schedules(schedule_id),
	start_datetime datetime NOT NULL,		
	end_datetime datetime NULL,
	actual_check_in_datetime datetime NULL,		
	actual_start_datetime datetime NULL,		
	actual_end_datetime datetime NULL,		
	appointment_code int NOT NULL,
	appointment_status_id smallint NOT NULL,		
	symptom varchar(1024) NULL,		
	cancel_reason varchar(1024) NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);

CREATE TABLE 	fcm_device_tokens		(
	fcm_device_token_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`fcm_device_token_id`),		
	device_token varchar(1024) NOT NULL,		
	user_id char(36) NULL, FOREIGN KEY (user_id) REFERENCES users(user_id),		
	language_id tinyint NOT NULL,		
	platform char(3) NULL,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	last_success_time_at_utc datetime NOT NULL DEFAULT NOW()		
			);
			
CREATE TABLE 	notification_objects		(
	notification_object_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`notification_object_id`),		
	title_en varchar(256) NOT NULL,
	body_en varchar(1024) NOT NULL,
	title_vi varchar(256) NOT NULL,
	body_vi varchar(1024) NOT NULL,
	data_json varchar(1024) NULL,
	sender_id char(36) NULL, FOREIGN KEY (sender_id) REFERENCES users(user_id),
	send_at_utc datetime NOT NULL DEFAULT NOW(),
	is_sent bit(1) NOT NULL DEFAULT 0,
	actual_sent_at_utc datetime NULL,
	is_deleted bit(1) NOT NULL DEFAULT 0,
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);
			
CREATE TABLE 	notifications		(
	notification_id bigint NOT NULL AUTO_INCREMENT, PRIMARY KEY(`notification_id`),		
	notification_object_id bigint NOT NULL, FOREIGN KEY (notification_object_id) REFERENCES notification_objects(notification_object_id),		
	notifier_id char(36) NOT NULL, FOREIGN KEY (notifier_id) REFERENCES users(user_id),		
	is_read bit(1) NOT NULL DEFAULT 0,		
	is_deleted bit(1) NOT NULL DEFAULT 0,		
	created_at_utc datetime NOT NULL DEFAULT NOW(),		
	updated_at_utc datetime NOT NULL DEFAULT NOW(),		
	created_by_user_id char(36) NULL,		
	updated_by_user_id char(36) NULL		
			);