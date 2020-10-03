create table if not exists "Address"
(
	"Id" uuid not null
		constraint address_pk
			primary key,
	"Line1" varchar not null,
	"Line2" varchar,
	"City" varchar not null,
	"Region" varchar not null,
	"Country" varchar not null,
	"AreaCode" varchar not null
);

alter table "Address" owner to docker;

create table if not exists "Location"
(
	"Id" uuid not null
		constraint location_pk
			primary key,
	"Name" varchar not null,
	"Description" varchar,
	"AddressId" uuid not null
		constraint location_address_id_fk
			references "Address"
);

comment on table "Location" is 'A single location that will host events';

alter table "Location" owner to docker;

create table if not exists "Room"
(
	"Id" uuid not null
		constraint room_pk
			primary key,
	"Name" varchar not null,
	"Description" text,
	"Occupancy" integer not null,
	"LocationId" uuid not null
		constraint room_location_id_fk
			references "Location"
);

comment on table "Room" is 'An individual room that is available for any purpose';

alter table "Room" owner to docker;

create unique index if not exists room_id_uindex
	on "Room" ("Id");

create unique index if not exists location_id_uindex
	on "Location" ("Id");

create unique index if not exists address_id_uindex
	on "Address" ("Id");

create table if not exists "Course"
(
	"Id" uuid not null
		constraint course_pk
			primary key,
	"Name" varchar not null,
	"Description" text
);

comment on table "Course" is 'A course that is happening at the event';

alter table "Course" owner to docker;

create unique index if not exists course_id_uindex
	on "Course" ("Id");

create table if not exists "Vendor"
(
	"Id" uuid not null
		constraint vendor_pk
			primary key,
	"Name" varchar not null,
	"ContactFirstName" varchar not null,
	"ContactLactName" varchar not null,
	"ContactEmail" varchar not null,
	"ContactPhone" varchar not null,
	"GeneralEmail" varchar not null,
	"GeneralPhone" varchar not null
);

comment on table "Vendor" is 'A vendor that has registered for the event';

alter table "Vendor" owner to docker;

create unique index if not exists vendor_id_uindex
	on "Vendor" ("Id");

create table if not exists "Instructor"
(
	"Id" varchar not null
		constraint instructor_pk
			primary key,
	"FirstName" varchar not null,
	"LastName" varchar not null,
	"Bio" text not null
);

comment on table "Instructor" is 'Instructors that have registed to talk at the event';

alter table "Instructor" owner to docker;

create unique index if not exists instructor_id_uindex
	on "Instructor" ("Id");

create table if not exists "Event"
(
	"Id" uuid not null
		constraint event_pk
			primary key,
	"Name" varchar not null,
	"StartTime" date not null,
	"EndTime" date not null,
	"RoomId" uuid not null
		constraint event_room_id_fk
			references "Room"
);

comment on table "Event" is 'Some event that is happening';

alter table "Event" owner to docker;

create unique index if not exists event_id_uindex
	on "Event" ("Id");

create table if not exists "Attendee"
(
	"Id" uuid not null,
	"FirstName" varchar not null,
	"LatName" varchar not null,
	"AddressId" uuid not null
		constraint attendee_address_id_fk
			references "Address",
	"Email" varchar not null,
	"Phone" varchar not null
);

comment on table "Attendee" is 'Somebody that is attending the event';

alter table "Attendee" owner to docker;

create unique index if not exists attendee_email_uindex
	on "Attendee" ("Email");

create unique index if not exists attendee_id_uindex
	on "Attendee" ("Id");

