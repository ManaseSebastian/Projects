%Desenez 1
function L=D1(x)
hold on
t=1.75:3.2;
t1=0.25:1.5;
L=plot(t-t+3+x,t,'b',t1-t1+3+x,t1,'b'); 
end