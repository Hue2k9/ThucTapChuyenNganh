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
public class NhanVienSX extends  NhanVien{
    private int soSanPham;
    public NhanVienSX(String maNV){
        super();
        soSanPham=0;
    }
    public NhanVienSX(){
        super();
        soSanPham=0;
    }

    public NhanVienSX(String maNV,String tenNV, int nam, int soSanPham ) {
        super(maNV,tenNV, nam);
        this.soSanPham = soSanPham;
    }
    
    @Override
    public double tinhLuong() {
        return soSanPham*10000;
    }
    public void nhap(){
        super.nhap();
        Scanner sn=new Scanner(System.in);
        System.out.print("Nhap so san pham: ");
        soSanPham=sn.nextInt();
    }
    static void inTieuDe(){
        NhanVien.inTieuDe();
        System.out.printf("%10s %15s %15s %n","So sp","phu cap","Luong");
    }
    public void xuatDL(){
        super.xuatDL();
        System.out.printf("%10s %15s %15s %n",soSanPham, tinhPhuCap(),tinhLuong());
    }
    public void setSoSamPham(int soSanPham){
        this.soSanPham=soSanPham;
    }
    public int getSoSanPham(){
        return soSanPham;
    }
}
