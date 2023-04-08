/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package QuanLyNhanVien;

import java.time.LocalDate;
import java.util.Date;
import java.util.Scanner;

/**
 *
 * @author IT Supporter
 */
public abstract class NhanVien {
    private String maNV;
    private String hoTen;
    private int namVaoLam;
    static double tongLuong;
    final double PHUCCAP_BANDAU=100000;
    abstract public double tinhLuong();
    
    public String getMaNV(){
        return maNV;
    }
    public NhanVien(){
        this.maNV="nv01";
        this.hoTen="";
        this.namVaoLam=200;
    }
    public NhanVien(String maNV,String hoTen, int nam) {
        this.maNV = maNV;
        this.hoTen=hoTen;
        this.namVaoLam=nam;
    }
    protected double tinhPhuCap(){
        Date now= new Date();
        int d=LocalDate.now().getYear();
        return PHUCCAP_BANDAU+(d-namVaoLam)*20000;
    }
    public void nhap(){
        Scanner sn=new Scanner(System.in);
        System.out.print("Nhap ma nhan vien:");
        maNV=sn.nextLine();
        System.out.print("Nhap ho ten:");
        hoTen=sn.nextLine();
        System.out.print("Nhap nam vao lam:");
        namVaoLam=sn.nextInt();
    }
    static void inTieuDe(){
        System.out.printf("%-15s 515s %15s","Ma NV","Ho ten","Nam vao lam");
    }
    public void xuatDL(){
        System.out.printf("%-15s 515s %15s",maNV, hoTen, namVaoLam);
    }
}
