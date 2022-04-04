%Desenez 3
function L=D3(x)
t=2.1:0.1:2.9;
t1=1.75:3.2;
t2=0.25:1.5;
hold on
L=plot(t+x,t-t+0,'b',t+x,t-t+3,'b',t+x,t-t+1.5,'b',t1-t1+3+x,t1,'b',t2-t2+3+x,t2,'b');
end