s=0;m=0;
fig=figure;
x1=1; x2=10;y1=-1;y2=4;
axis([x1,x2,y1,y2])

while true
    if ~ishghandle(fig)
        break;
    end
    L1=Cifra(6,mod(s,10));
    L2=Cifra(4,fix(s/10));
    L3=Cifra(2,mod(m,10));
    L4=Cifra(0,fix(m/10));
    if(s==59)
        s=-1;
        m=m+1;
    end
    if(m==60)
        m=0;
    end
    pause(1);
    s=s+1;
    delete(L1);
    delete(L2);
    delete(L3);
    delete(L4);
end
