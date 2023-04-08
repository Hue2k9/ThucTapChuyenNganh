/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package QuanLyNhanVien;

import java.util.Comparator;

/**
 *
 * @author IT Supporter
 */
public class SortByLuong implements Comparator<NhanVien>{
    public int compare(NhanVien o1, NhanVien o2){
        return Double.compare(o1.tinhLuong(),o2.tinhLuong());
    }
}
