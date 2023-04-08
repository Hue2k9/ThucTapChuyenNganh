/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package QuanLyNhanVien;

import java.util.Scanner;

/**
 *
 * @author IT Supporter
 */
public class NhanVienVP extends NhanVien{
    private int soNgayNghi;
    private float mucLuong;

    @Override
    public double tinhLuong() {
        return mucLuong - soNgayNghi*10000;
    }
    public void nhap(){
        super.nhap();
        Scanner sn=new Scanner(System.in);
        System.out.print("Nhap so ngay nghi: ");
        soNgayNghi=sn.nextInt();
        System.out.print("Muc luong:");
        mucLuong=sn.nextFloat();
    }
    static void inTieuDe(){
        NhanVien.inTieuDe();
        System.out.printf("%10s %15s %15s %n","So ngay nghi","muc luong","phu cap","Luong");
    }
    public final void xuatDL(){
        super.xuatDL();
        System.out.printf("%10s %15s %15s %n",soNgayNghi,mucLuong,tinhPhuCap(),tinhLuong());
    }

    @Override
    public String toString() {
        return super.toString()+ "\t so ngay nghi:" + soNgayNghi+"\t muc luong"+mucLuong;
    }
    
}
