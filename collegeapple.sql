delete  address;
insert into address values('a1','Nepal','Kathmandu', 6622);
insert into address values('a2','Nepal','Pokhara',   6283);
insert into address values('a3','Nepal','Chitwan',   8482);
insert into address values('a4','Nepal','Birjung',   9648);
insert into address values('a5','Nepal','Kathmandu', 6248);
insert into address values('a6','India','Dehli',     1648);
insert into address values('a7','China','bejing',    2648);
insert into address values('a8','USA','New York',     1648);
insert into address values('a9','USA','Texas',    2628);
insert into address values('a10','UK','London',     1228);
insert into address values('a11','Nepal','Kathmandu',    2622);

insert into person values('ghale','Samrat','p1','a1','samrat@gmail.com');
insert into person values('thug','young','p2','a2','youngthug@gmail.com');
insert into person values('drake','drizzy','p3','a3','champainepapi@gmail.com');
insert into person values('z','jay','p4','a4','jayz@gmail.com');
insert into person values('cole','J','p5','a5','jCole@gmail.com');

insert into course values('c1', 'CS', 3, 1500);
insert into course values('c2', 'CE', 4, 1800);
insert into course values('c3', 'DBA', 3, 500);
insert into course values('c4', 'BBA', 2, 1200);
insert into course values('c5', 'BA', 3, 1000);

insert into student values('s1','p1','c1',2);
insert into student values('s2','p2','c1',1);
insert into student values('s3','p3','c2',3);
insert into student values('s4','p4','c2',2);
insert into student values('s5','p5','c2',2);

insert into module values('m1','cs1001','Application development',2,100);
insert into module values('m2','cs1002','Advanced Database',1,90);
insert into module values('m3','cs1003','Logic',3,50);
insert into module values('m4','cs1004','Java',5,170);
insert into module values('m5','cs1005','AI',7,180);

insert into person values('soul','Ab','p6','a7','absoul@gmail.com');
insert into person values('lamar','kendrick','p7','a7','kendrick@gmail.com');

insert into person values('Buddha','Yama','p8','a8','yama@gmail.com');
insert into person values('Gambino','Childish','p9','a9','gambino@gmail.com');
insert into person values('Hill','Lauryn','p10','a10','lauryn@gmail.com');

insert into teacher values('t1', 'p6', 'TA',15000);
insert into teacher values('t2', 'p7', 'Lectoror',20000);
insert into teacher values('t3', 'p8', 'Tutor',15000);
insert into teacher values('t4', 'p9', 'Module Head',25000);
insert into teacher values('t5', 'p10', 'Tutor',10000);

insert into teacher_module values('t1','m1');
insert into teacher_module values('t2','m1');
insert into teacher_module values('t3','m2');
insert into teacher_module values('t4','m2');
insert into teacher_module values('t5','m3');
insert into teacher_module values('t1','m3');
insert into teacher_module values('t2','m4');
insert into teacher_module values('t3','m4');
insert into teacher_module values('t4','m5');
insert into teacher_module values('t5','m5');

insert into attendence values('




commit;
select * from teacher;