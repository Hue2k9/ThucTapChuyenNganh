/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package QuanLyNhanVien;

import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.Collection;
import java.util.Scanner;

/**
 *
 * @author IT Supporter
 */
public class NhanVienDomo {
    static int soNV, loaiNV;
    static double tongLuong=0f;
    static NhanVien myMV[];
   
    
    static void nhapDL(){
        Scanner sn=  new Scanner(System.in);
        System.out.print("Nhap so luong nhan vien: ");
        soNV=sn.nextInt();
        soNV=soNV+3;
                
        myMV= new NhanVien[soNV];
        fakeData();
        for(int i=3; i<soNV; i++){
            System.out.println("1.Nhap NVSX, 2.NVVP");
            loaiNV=sn.nextInt();
            if(loaiNV==1) myMV[i]=new NhanVienSX();
            else myMV[i]=new NhanVienVP();
            myMV[i].nhap();
            tongLuong=tongLuong+ myMV[i].tinhLuong() + myMV[i].tinhPhuCap();
        }
    }
    static void inDL(){
        System.out.println("\n Danh sach nhan vien SX cong ty la");
        NhanVienSX.inTieuDe();
        for(int i=0; i<soNV; i++){
            if(myMV[i] instanceof NhanVienSX) myMV[i].xuatDL();
        }
        
        System.out.println("\n Danh sach nhan vien VP cong ty la");
        NhanVienSX.inTieuDe();
        for(int i=0; i<soNV; i++)
            if(myMV[i] instanceof NhanVienVP) myMV[i].xuatDL();
        DecimalFormat f= new DecimalFormat("###,###.0#");
        System.out.println("\n Tong luong nhan vien: " +f.format(tongLuong));
    }
    public static void main(String[] args){   
        nhapDL();
        inDL();
    }

    public  static void fakeData() {
        NhanVienSX sx1=new NhanVienSX("NV01","Thuy",29,10);
        myMV[0]=sx1;
        NhanVienSX sx2=new NhanVienSX("NV01","Ahuy",29,10);
        myMV[1]=sx2;
        NhanVienSX sx3=new NhanVienSX("NV01","Bhuy",29,10);
        myMV[2]=sx3;
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    private static void sapTheoTen(){
        Collection.sort(Arrays.asList(myMV));
        System.out.println("Danh sach sao ten");
        inDL();;
    }
    private static void maxByLuong(){
        System.out.println("Max Luong");
        Collection.max(Arrays.asList(myMV));
        new SortByLuong().inDL();
    }
}
