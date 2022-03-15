set serveroutput on;

declare

begin

for c1 in (select y1.table_name, y1.constraint_name from user_constraints y1, user_tables x1 where x1.table_name = y1.table_name order by y1.r_constraint_name nulls last) loop
    begin
        dbms_output.put_line('alter table '||c1.table_name||' disable constraint '||c1.constraint_name || ';');
        execute immediate  ('alter table '||c1.table_name||' disable constraint '||c1.constraint_name);
    end;
end loop;

for t1 in (select table_name from user_tables) loop
    begin
        dbms_output.put_line('truncate table '||t1.table_name || ';');    
        execute immediate ('truncate table '||t1.table_name);
    end;
end loop;

for c2 in (select y2.table_name, y2.constraint_name from user_constraints y2, user_tables x2 where x2.table_name = y2.table_name order by y2.r_constraint_name nulls first) loop
    begin
        dbms_output.put_line('alter table '||c2.table_name||' enable constraint '||c2.constraint_name || ';');        
        execute immediate ('alter table '||c2.table_name||' enable constraint '||c2.constraint_name);
    end;
end loop;

end;
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

delete person;
insert into person values('ghale','Samrat','p1','a1','samrat@gmail.com');
insert into person values('thug','young','p2','a2','youngthug@gmail.com');
insert into person values('drake','drizzy','p3','a3','champainepapi@gmail.com');
insert into person values('z','jay','p4','a4','jayz@gmail.com');
insert into person values('cole','J','p5','a5','jCole@gmail.com');

delete course;
insert into course values('c1', 'CS', 3, 1500);
insert into course values('c2', 'CE', 4, 1800);
insert into course values('c3', 'DBA', 3, 500);
insert into course values('c4', 'BBA', 2, 1200);
insert into course values('c5', 'BA', 3, 1000);

delete student;
insert into student values('s1','p1','c1',2);
insert into student values('s2','p2','c1',1);
insert into student values('s3','p3','c2',3);
insert into student values('s4','p4','c2',2);
insert into student values('s5','p5','c2',2);

delete module;
insert into module values('m1','cs1001','App dev',2,100);
insert into module values('m2','cs1002','Database',1,90);
insert into module values('m3','cs1003','Logic',3,50);
insert into module values('m4','cs1004','Java',5,170);
insert into module values('m5','cs1005','AI',7,180);

insert into person values('soul','Ab','p6','a7','absoul@gmail.com');
insert into person values('lamar','kendrick','p7','a7','kendrick@gmail.com');

insert into person values('Buddha','Yama','p8','a8','yama@gmail.com');
insert into person values('Gambino','Childish','p9','a9','gambino@gmail.com');
insert into person values('Hill','Lauryn','p10','a10','lauryn@gmail.com');

delete teacher;
insert into teacher values('t1', 'p6', 'TA',15000);
insert into teacher values('t2', 'p7', 'Lectoror',20000);
insert into teacher values('t3', 'p8', 'Tutor',15000);
insert into teacher values('t4', 'p9', 'Module Head',25000);
insert into teacher values('t5', 'p10', 'Tutor',10000);

delete teacher_module;
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

delete department;
insert into department values('D1','Finance', 'Handles the finance of the college');
insert into department values('D2','RTE', 'Handles results timetable and exams');
insert into department values('D3','SS', 'Handles student queries');
insert into department values('D4','HR', 'Human resources');
insert into department values('D5','Marketing', 'Makets the college');

delete payment;
insert into payment values('PAY1', 's1',200,1, TO_DATE('2021/05/02','yyyy/mm/dd'),'D1');
insert into payment values('PAY2', 's2',120,2, TO_DATE('2021/02/02','yyyy/mm/dd'),'D1');
insert into payment values('PAY3', 's3',220,1, TO_DATE('2021/03/12','yyyy/mm/dd'),'D1');
insert into payment values('PAY4', 's4',300,2, TO_DATE('2021/02/22','yyyy/mm/dd'),'D1');
insert into payment values('PAY5', 's5',200,1, TO_DATE('2021/01/30','yyyy/mm/dd'),'D1');
insert into payment values('PAY6', 's1',300,1, TO_DATE('2021/11/01','yyyy/mm/dd'),'D1');
insert into payment values('PAY7', 's2',100,3, TO_DATE('2021/12/21','yyyy/mm/dd'),'D1');
insert into payment values('PAY8', 's3',410,2, TO_DATE('2021/11/22','yyyy/mm/dd'),'D1');
insert into payment values('PAY9', 's4',190,2, TO_DATE('2021/10/12','yyyy/mm/dd'),'D1');
insert into payment values('PAY10', 's5',400,1, TO_DATE('2021/05/02','yyyy/mm/dd'),'D1');

delete assignment;
insert into assignment values('A1', 'MCQ', 'D2');
insert into assignment values('A2', 'Coursework', 'D2');
insert into assignment values('A3', 'Coursework', 'D2');
insert into assignment values('A4', 'Viva', 'D2');
insert into assignment values('A5', 'Coursework', 'D2');
insert into assignment values('A6', 'MCQ', 'D2');
insert into assignment values('A7', 'MCQ', 'D2');

delete module_assignment;
insert into module_assignment values('A1', 'm1','MCQ');
insert into module_assignment values('A2', 'm1','Coursework');
insert into module_assignment values('A3', 'm2','Coursework');
insert into module_assignment values('A4', 'm3','Viva');
insert into module_assignment values('A5', 'm2','Coursework');
insert into module_assignment values('A6', 'm1','MCQ');
insert into module_assignment values('A7', 'm2','MCQ');

delete result;

insert into result values('R1', 'm1','A1', 's1',80,'Pass');
insert into result values('R2', 'm2','A2', 's2',80,'Pass');
insert into result values('R3', 'm3','A3', 's3',30,'Fail');
insert into result values('R4', 'm3','A4', 's4',40,'Fail');
insert into result values('R5', 'm1','A5', 's5',43,'Pass');
insert into result values('R6', 'm5','A2', 's4',92,'Pass');
insert into result values('R7', 'm1','A2', 's1',80,'Pass');
insert into result values('R8', 'm2','A3', 's2',30,'Fail');
insert into result values('R9', 'm3','A4', 's3',50,'Fail');
insert into result values('R10', 'm2','A5', 's4',50,'Pass');
insert into result values('R11', 'm1','A6', 's5',80,'Pass');

delete attendance;
insert into attendance values('s1', 'm1', TO_DATE('2021/10/01','yyyy/mm/dd'), 'D3');
insert into attendance values('s2', 'm1', TO_DATE('2021/11/02','yyyy/mm/dd'), 'D3');
insert into attendance values('s3', 'm2', TO_DATE('2021/10/12','yyyy/mm/dd'), 'D3');
insert into attendance values('s4', 'm2', TO_DATE('2021/11/01','yyyy/mm/dd'), 'D3');
insert into attendance values('s5', 'm3', TO_DATE('2021/12/12','yyyy/mm/dd'), 'D3');
insert into attendance values('s1', 'm3', TO_DATE('2021/02/18','yyyy/mm/dd'), 'D3');
insert into attendance values('s2', 'm4', TO_DATE('2021/03/21','yyyy/mm/dd'), 'D3');
insert into attendance values('s3', 'm4', TO_DATE('2021/07/09','yyyy/mm/dd'), 'D3');
insert into attendance values('s4', 'm5', TO_DATE('2021/08/01','yyyy/mm/dd'), 'D3');
insert into attendance values('s5', 'm5', TO_DATE('2021/09/01','yyyy/mm/dd'), 'D3');

delete module_course;
insert into module_course values('c1', 'm1');
insert into module_course values('c2', 'm1');
insert into module_course values('c3', 'm2');
insert into module_course values('c4', 'm2');
insert into module_course values('c5', 'm3');
insert into module_course values('c1', 'm3');
insert into module_course values('c2', 'm4');
insert into module_course values('c3', 'm4');
insert into module_course values('c4', 'm5');
insert into module_course values('c5', 'm5');

commit;
