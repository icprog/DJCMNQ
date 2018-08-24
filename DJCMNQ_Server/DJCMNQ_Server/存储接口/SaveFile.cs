using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DJCMNQ_Server.存储接口
{
    class SaveFile
    {
        public static ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_Async = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_1 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_2 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_3 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_4 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_5 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_6 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_7 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_8 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_9 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_10 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_11 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_12 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_13 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_14 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_15 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_16 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_17 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_18 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_19 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_20 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_21 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_22 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_23 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_24 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_25 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_26 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_27 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_28 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_29 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_30 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_31 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_32 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_33 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_34 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_35 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_36 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_37 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_38 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_39 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_40 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_41 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_42 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_43 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_44 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_45 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_46 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_47 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_48 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_49 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_50 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_51 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_52 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_53 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_54 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_55 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_56 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_57 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_58 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_59 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_60 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_61 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_62 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_63 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_64 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_65 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_66 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_67 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_68 = new ReaderWriterLockSlim();


        public static List<ReaderWriterLockSlim> myLock = new List<ReaderWriterLockSlim>();

        public static ReaderWriterLockSlim Lock_asyn_1 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_2 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_3 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_4 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_5 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_6 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_7 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_8 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_9 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_10 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_11 = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim Lock_asyn_12 = new ReaderWriterLockSlim();


        public static List<ReaderWriterLockSlim> myLockforAsync = new List<ReaderWriterLockSlim>();
        //在网络收发线程中给DataQueue赋值

        public static Queue<byte[]> DataQueue_0 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC1 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC2 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC3 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC4 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC5 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC6 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC7 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC8 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC9 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC10 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC11 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC12 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC13 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC14 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC15 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC16 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC17 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC18 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC19 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC20 = new Queue<byte[]>();

        public static Queue<byte[]> DataQueue_SC21 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC22 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC23 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC24 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC25 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC26 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC27 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC28 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC29 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC30 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC31 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC32 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC33 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC34 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC35 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC36 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC37 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC38 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC39 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC40 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC41 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC42 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC43 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC44 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC45 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC46 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC47 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC48 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC49 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC50 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC51 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC52 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC53 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC54 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC55 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC56 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC57 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC58 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC59 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC60 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC61 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC62 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC63 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC64 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC65 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC66 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC67 = new Queue<byte[]>();
        public static Queue<byte[]> DataQueue_SC68 = new Queue<byte[]>();




        public static Queue<byte[]> DataQueue_Async = new Queue<byte[]>();

        public static List<Queue<byte[]>> DataQueueList = new List<Queue<byte[]>>();

        public static bool SaveOn = true;

        FileStream file0, file_async;
        FileStream file_SC1, file_SC2, file_SC3, file_SC4,
            file_SC5, file_SC6, file_SC7, file_SC8,
            file_SC9, file_SC10, file_SC11, file_SC12,
            file_SC13, file_SC14, file_SC15, file_SC16,
            file_SC17, file_SC18, file_SC19, file_SC20,
            file_SC21, file_SC22, file_SC23, file_SC24,
            file_SC25, file_SC26, file_SC27, file_SC28,
            file_SC29, file_SC30, file_SC31, file_SC32,
            file_SC33, file_SC34, file_SC35, file_SC36,
            file_SC37, file_SC38, file_SC39, file_SC40,
            file_SC41, file_SC42, file_SC43, file_SC44,
            file_SC45, file_SC46, file_SC47, file_SC48,
            file_SC49, file_SC50, file_SC51, file_SC52,
            file_SC53, file_SC54, file_SC55, file_SC56,
            file_SC57, file_SC58, file_SC59, file_SC60,
            file_SC61, file_SC62, file_SC63, file_SC64,
            file_SC65, file_SC66, file_SC67, file_SC68;
        List<FileStream> myFileList_dat = new List<FileStream>();

        FileStream file_asyn1, file_asyn2, file_asyn3, file_asyn4, file_asyn5, file_asyn6,
            file_asyn7, file_asyn8, file_asyn9, file_asyn10, file_asyn11, file_asyn12;
        List<FileStream> myFileList_txt = new List<FileStream>();

        public static Queue<string> DataQueue_asyn_1 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_2 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_3 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_4 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_5 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_6 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_7 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_8 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_9 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_10 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_GNC1 = new Queue<string>();
        public static Queue<string> DataQueue_asyn_GNC2 = new Queue<string>();
        public static List<Queue<string>> DataQueue_asynList = new List<Queue<string>>();
        //在主页面初始化时，调用FileInit()和FileSaveStart(),分别初始化文件夹和开始存储

        /// <summary>
        /// 存储线程初始化
        /// </summary>
        public void FileInit()
        {
            Trace.WriteLine("Start FileInit!\n");

            string MaBen_path = Program.GetStartupPath() + @"码本文件\";
            if (!Directory.Exists(MaBen_path))
                Directory.CreateDirectory(MaBen_path);

            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\源码\", out file_SC1);

            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF01\", out file_SC2);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF02\", out file_SC3);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF03\", out file_SC4);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF04\", out file_SC5);

            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF08\", out file_SC6);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF08\1D00\", out file_SC7);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF08\1D01\", out file_SC8);
            FileCreateDat(Program.GetStartupPath() + @"存储数据\AD机箱数据\FF08\1D08\", out file_SC9);

            FileCreateDat(Program.GetStartupPath() + @"存储数据\OC机箱数据\源码\", out file_SC10);

            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\数管A机发送数传终端机A\", out file_SC11);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\数管A机发送数传终端机B\", out file_SC12);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\A机LVDS发送3\", out file_SC13);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\A机LVDS发送4\", out file_SC14);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\数管B机发送数传终端机A\", out file_SC15);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\数管B机发送数传终端机B\", out file_SC16);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\B机LVDS发送3\", out file_SC17);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\B机LVDS发送4\", out file_SC18);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\LVDS机箱数据\源码\", out file_SC19);

            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\源码\", out file_SC20);

            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D00\", out file_SC21);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D01\", out file_SC22);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D02\", out file_SC23);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D03\", out file_SC24);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D04\", out file_SC25);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D05\", out file_SC26);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D06\", out file_SC27);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D07\", out file_SC28);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D08\", out file_SC29);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D09\", out file_SC30);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0A\", out file_SC31);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0B\", out file_SC32);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0C\", out file_SC33);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0D\", out file_SC34);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0E\", out file_SC35);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF05\1D0F\", out file_SC36);

            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D00\", out file_SC37);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D01\", out file_SC38);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D02\", out file_SC39);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D03\", out file_SC40);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D04\", out file_SC41);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D05\", out file_SC42);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D06\", out file_SC43);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D07\", out file_SC44);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D08\", out file_SC45);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D09\", out file_SC46);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0A\", out file_SC47);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0B\", out file_SC48);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0C\", out file_SC49);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0D\", out file_SC50);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0E\", out file_SC51);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF06\1D0F\", out file_SC52);

            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D00\", out file_SC53);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D01\", out file_SC54);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D02\", out file_SC55);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D03\", out file_SC56);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D04\", out file_SC57);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D05\", out file_SC58);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D06\", out file_SC59);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D07\", out file_SC60);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D08\", out file_SC61);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D09\", out file_SC62);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0A\", out file_SC63);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0B\", out file_SC64);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0C\", out file_SC65);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0D\", out file_SC66);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0E\", out file_SC67);
            //FileCreateDat(Program.GetStartupPath() + @"存储数据\RS422机箱数据\FF07\1D0F\", out file_SC68);


            //        FileCreateDat(Program.GetStartupPath() + @"异步422\", out file_async);
            DataQueueList.Add(DataQueue_SC1);
            DataQueueList.Add(DataQueue_SC2);
            DataQueueList.Add(DataQueue_SC3);
            DataQueueList.Add(DataQueue_SC4);
            DataQueueList.Add(DataQueue_SC5);
            DataQueueList.Add(DataQueue_SC6);
            DataQueueList.Add(DataQueue_SC7);
            DataQueueList.Add(DataQueue_SC8);
            DataQueueList.Add(DataQueue_SC9);
            DataQueueList.Add(DataQueue_SC10);
            DataQueueList.Add(DataQueue_SC11);
            DataQueueList.Add(DataQueue_SC12);
            DataQueueList.Add(DataQueue_SC13);
            DataQueueList.Add(DataQueue_SC14);
            DataQueueList.Add(DataQueue_SC15);
            DataQueueList.Add(DataQueue_SC16);
            DataQueueList.Add(DataQueue_SC17);
            DataQueueList.Add(DataQueue_SC18);
            DataQueueList.Add(DataQueue_SC19);
            DataQueueList.Add(DataQueue_SC20);

            DataQueueList.Add(DataQueue_SC21);
            DataQueueList.Add(DataQueue_SC22);
            DataQueueList.Add(DataQueue_SC23);
            DataQueueList.Add(DataQueue_SC24);
            DataQueueList.Add(DataQueue_SC25);
            DataQueueList.Add(DataQueue_SC26);
            DataQueueList.Add(DataQueue_SC27);
            DataQueueList.Add(DataQueue_SC28);
            DataQueueList.Add(DataQueue_SC29);
            DataQueueList.Add(DataQueue_SC30);
            DataQueueList.Add(DataQueue_SC31);
            DataQueueList.Add(DataQueue_SC32);
            DataQueueList.Add(DataQueue_SC33);
            DataQueueList.Add(DataQueue_SC34);
            DataQueueList.Add(DataQueue_SC35);
            DataQueueList.Add(DataQueue_SC36);
            DataQueueList.Add(DataQueue_SC37);
            DataQueueList.Add(DataQueue_SC38);
            DataQueueList.Add(DataQueue_SC39);
            DataQueueList.Add(DataQueue_SC40);
            DataQueueList.Add(DataQueue_SC41);
            DataQueueList.Add(DataQueue_SC42);
            DataQueueList.Add(DataQueue_SC43);
            DataQueueList.Add(DataQueue_SC44);
            DataQueueList.Add(DataQueue_SC45);
            DataQueueList.Add(DataQueue_SC46);
            DataQueueList.Add(DataQueue_SC47);
            DataQueueList.Add(DataQueue_SC48);
            DataQueueList.Add(DataQueue_SC49);
            DataQueueList.Add(DataQueue_SC50);
            DataQueueList.Add(DataQueue_SC51);
            DataQueueList.Add(DataQueue_SC52);
            DataQueueList.Add(DataQueue_SC53);
            DataQueueList.Add(DataQueue_SC54);
            DataQueueList.Add(DataQueue_SC55);
            DataQueueList.Add(DataQueue_SC56);
            DataQueueList.Add(DataQueue_SC57);
            DataQueueList.Add(DataQueue_SC58);
            DataQueueList.Add(DataQueue_SC59);
            DataQueueList.Add(DataQueue_SC60);
            DataQueueList.Add(DataQueue_SC61);
            DataQueueList.Add(DataQueue_SC62);
            DataQueueList.Add(DataQueue_SC63);
            DataQueueList.Add(DataQueue_SC64);
            DataQueueList.Add(DataQueue_SC65);
            DataQueueList.Add(DataQueue_SC66);
            DataQueueList.Add(DataQueue_SC67);
            DataQueueList.Add(DataQueue_SC68);


            myLock.Add(Lock_1);
            myLock.Add(Lock_2);
            myLock.Add(Lock_3);
            myLock.Add(Lock_4);
            myLock.Add(Lock_5);
            myLock.Add(Lock_6);
            myLock.Add(Lock_7);
            myLock.Add(Lock_8);
            myLock.Add(Lock_9);
            myLock.Add(Lock_10);
            myLock.Add(Lock_11);
            myLock.Add(Lock_12);
            myLock.Add(Lock_13);
            myLock.Add(Lock_14);
            myLock.Add(Lock_15);
            myLock.Add(Lock_16);
            myLock.Add(Lock_17);
            myLock.Add(Lock_18);
            myLock.Add(Lock_19);
            myLock.Add(Lock_20);

            myLock.Add(Lock_21);
            myLock.Add(Lock_22);
            myLock.Add(Lock_23);
            myLock.Add(Lock_24);
            myLock.Add(Lock_25);
            myLock.Add(Lock_26);
            myLock.Add(Lock_27);
            myLock.Add(Lock_28);
            myLock.Add(Lock_29);
            myLock.Add(Lock_30);
            myLock.Add(Lock_31);
            myLock.Add(Lock_32);
            myLock.Add(Lock_33);
            myLock.Add(Lock_34);
            myLock.Add(Lock_35);
            myLock.Add(Lock_36);
            myLock.Add(Lock_37);
            myLock.Add(Lock_38);
            myLock.Add(Lock_39);
            myLock.Add(Lock_40);
            myLock.Add(Lock_41);
            myLock.Add(Lock_42);
            myLock.Add(Lock_43);
            myLock.Add(Lock_44);
            myLock.Add(Lock_45);
            myLock.Add(Lock_46);
            myLock.Add(Lock_47);
            myLock.Add(Lock_48);
            myLock.Add(Lock_49);
            myLock.Add(Lock_50);
            myLock.Add(Lock_51);
            myLock.Add(Lock_52);
            myLock.Add(Lock_53);
            myLock.Add(Lock_54);
            myLock.Add(Lock_55);
            myLock.Add(Lock_56);
            myLock.Add(Lock_57);
            myLock.Add(Lock_58);
            myLock.Add(Lock_59);
            myLock.Add(Lock_60);
            myLock.Add(Lock_61);
            myLock.Add(Lock_62);
            myLock.Add(Lock_63);
            myLock.Add(Lock_64);
            myLock.Add(Lock_65);
            myLock.Add(Lock_66);
            myLock.Add(Lock_67);
            myLock.Add(Lock_68);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道1\", out file_asyn1);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道2\", out file_asyn2);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道3\", out file_asyn3);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道4\", out file_asyn4);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道5\", out file_asyn5);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道6\", out file_asyn6);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道7\", out file_asyn7);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道8\", out file_asyn8);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道9\", out file_asyn9);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道10\", out file_asyn10);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道GNC1\", out file_asyn11);
            //FileCreateTxt(Program.GetStartupPath() + @"异步422\通道GNC2\", out file_asyn12);

            //DataQueue_asynList.Add(DataQueue_asyn_1);
            //DataQueue_asynList.Add(DataQueue_asyn_2);
            //DataQueue_asynList.Add(DataQueue_asyn_3);
            //DataQueue_asynList.Add(DataQueue_asyn_4);
            //DataQueue_asynList.Add(DataQueue_asyn_5);
            //DataQueue_asynList.Add(DataQueue_asyn_6);
            //DataQueue_asynList.Add(DataQueue_asyn_7);
            //DataQueue_asynList.Add(DataQueue_asyn_8);
            //DataQueue_asynList.Add(DataQueue_asyn_9);
            //DataQueue_asynList.Add(DataQueue_asyn_10);
            //DataQueue_asynList.Add(DataQueue_asyn_GNC1);
            //DataQueue_asynList.Add(DataQueue_asyn_GNC2);



            //          WriteFileThread = new Thread(WriteToFile);
            //           WriteFileThread.Start(file1);
        }

        public void FileCreateDat(string Path, out FileStream file)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            DirectoryInfo folder = new DirectoryInfo(Path);
            try
            {
                foreach (FileInfo tempfile in folder.GetFiles("*.*"))
                {
                    string name = tempfile.Name;
                    if (tempfile.Length == 0)
                    {
                        Trace.WriteLine("删除文件" + tempfile.FullName);
                        File.Delete(tempfile.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                MyLog.Error(ex.Message);
            }

            string timestr = string.Format("{0}-{1:D2}-{2:D2} {3:D2}：{4:D2}：{5:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string filename = Path + timestr + ".dat";
            file = new FileStream(filename, FileMode.Create);
            myFileList_dat.Add(file);
        }

        public void FileCreateTxt(string Path, out FileStream file)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            string timestr = string.Format("{0}-{1:D2}-{2:D2} {3:D2}：{4:D2}：{5:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string filename = Path + timestr + ".txt";
            file = new FileStream(filename, FileMode.Create);
            myFileList_txt.Add(file);
        }

        public void FileSaveStart()
        {
            //MyLog.Info("开启存盘线程！");
            Trace.WriteLine("开启存盘线程");
            SaveOn = true;

            new Thread(() => { WriteToFileSC(0, file_SC1, ref DataQueue_SC1, ref Lock_1); }).Start();
            new Thread(() => { WriteToFileSC(1, file_SC2, ref DataQueue_SC2, ref Lock_2); }).Start();
            new Thread(() => { WriteToFileSC(2, file_SC3, ref DataQueue_SC3, ref Lock_3); }).Start();
            new Thread(() => { WriteToFileSC(3, file_SC4, ref DataQueue_SC4, ref Lock_4); }).Start();
            new Thread(() => { WriteToFileSC(4, file_SC5, ref DataQueue_SC5, ref Lock_5); }).Start();
            new Thread(() => { WriteToFileSC(5, file_SC6, ref DataQueue_SC6, ref Lock_6); }).Start();
            new Thread(() => { WriteToFileSC(6, file_SC7, ref DataQueue_SC7, ref Lock_7); }).Start();
            new Thread(() => { WriteToFileSC(7, file_SC8, ref DataQueue_SC8, ref Lock_8); }).Start();
            new Thread(() => { WriteToFileSC(8, file_SC9, ref DataQueue_SC9, ref Lock_9); }).Start();
            new Thread(() => { WriteToFileSC(9, file_SC10, ref DataQueue_SC10, ref Lock_10); }).Start();

            //new Thread(() => { WriteToFileSC(10, file_SC11, ref DataQueue_SC11, ref Lock_11); }).Start();
            //new Thread(() => { WriteToFileSC(11, file_SC12, ref DataQueue_SC12, ref Lock_12); }).Start();
            //new Thread(() => { WriteToFileSC(12, file_SC13, ref DataQueue_SC13, ref Lock_13); }).Start();
            //new Thread(() => { WriteToFileSC(13, file_SC14, ref DataQueue_SC14, ref Lock_14); }).Start();

            //new Thread(() => { WriteToFileSC(14, file_SC15, ref DataQueue_SC15, ref Lock_15); }).Start();
            //new Thread(() => { WriteToFileSC(15, file_SC16, ref DataQueue_SC16, ref Lock_16); }).Start();
            //new Thread(() => { WriteToFileSC(16, file_SC17, ref DataQueue_SC17, ref Lock_17); }).Start();
            //new Thread(() => { WriteToFileSC(17, file_SC18, ref DataQueue_SC18, ref Lock_18); }).Start();
            //new Thread(() => { WriteToFileSC(18, file_SC19, ref DataQueue_SC19, ref Lock_19); }).Start();

            //new Thread(() => { WriteToFileSC(19, file_SC20, ref DataQueue_SC20, ref Lock_20); }).Start();
            //new Thread(() => { WriteToFileSC(20, file_SC21, ref DataQueue_SC21, ref Lock_21); }).Start();
            //new Thread(() => { WriteToFileSC(21, file_SC22, ref DataQueue_SC22, ref Lock_22); }).Start();
            //new Thread(() => { WriteToFileSC(22, file_SC23, ref DataQueue_SC23, ref Lock_23); }).Start();
            //new Thread(() => { WriteToFileSC(23, file_SC24, ref DataQueue_SC24, ref Lock_24); }).Start();
            //new Thread(() => { WriteToFileSC(24, file_SC25, ref DataQueue_SC25, ref Lock_25); }).Start();
            //new Thread(() => { WriteToFileSC(25, file_SC26, ref DataQueue_SC26, ref Lock_26); }).Start();
            //new Thread(() => { WriteToFileSC(26, file_SC27, ref DataQueue_SC27, ref Lock_27); }).Start();
            //new Thread(() => { WriteToFileSC(27, file_SC28, ref DataQueue_SC28, ref Lock_28); }).Start();
            //new Thread(() => { WriteToFileSC(28, file_SC29, ref DataQueue_SC29, ref Lock_29); }).Start();
            //new Thread(() => { WriteToFileSC(29, file_SC30, ref DataQueue_SC30, ref Lock_30); }).Start();

            //new Thread(() => { WriteToFileSC(30, file_SC31, ref DataQueue_SC31, ref Lock_31); }).Start();
            //new Thread(() => { WriteToFileSC(31, file_SC32, ref DataQueue_SC32, ref Lock_32); }).Start();
            //new Thread(() => { WriteToFileSC(32, file_SC33, ref DataQueue_SC33, ref Lock_33); }).Start();
            //new Thread(() => { WriteToFileSC(33, file_SC34, ref DataQueue_SC34, ref Lock_34); }).Start();
            //new Thread(() => { WriteToFileSC(34, file_SC35, ref DataQueue_SC35, ref Lock_35); }).Start();
            //new Thread(() => { WriteToFileSC(35, file_SC36, ref DataQueue_SC36, ref Lock_36); }).Start();
            //new Thread(() => { WriteToFileSC(36, file_SC37, ref DataQueue_SC37, ref Lock_37); }).Start();
            //new Thread(() => { WriteToFileSC(37, file_SC38, ref DataQueue_SC38, ref Lock_38); }).Start();
            //new Thread(() => { WriteToFileSC(38, file_SC39, ref DataQueue_SC39, ref Lock_39); }).Start();
            //new Thread(() => { WriteToFileSC(39, file_SC40, ref DataQueue_SC40, ref Lock_40); }).Start();

            //new Thread(() => { WriteToFileSC(40, file_SC41, ref DataQueue_SC41, ref Lock_41); }).Start();
            //new Thread(() => { WriteToFileSC(41, file_SC42, ref DataQueue_SC42, ref Lock_42); }).Start();
            //new Thread(() => { WriteToFileSC(42, file_SC43, ref DataQueue_SC43, ref Lock_43); }).Start();
            //new Thread(() => { WriteToFileSC(43, file_SC44, ref DataQueue_SC44, ref Lock_44); }).Start();
            //new Thread(() => { WriteToFileSC(44, file_SC45, ref DataQueue_SC45, ref Lock_45); }).Start();
            //new Thread(() => { WriteToFileSC(45, file_SC46, ref DataQueue_SC46, ref Lock_46); }).Start();
            //new Thread(() => { WriteToFileSC(46, file_SC47, ref DataQueue_SC47, ref Lock_47); }).Start();
            //new Thread(() => { WriteToFileSC(47, file_SC48, ref DataQueue_SC48, ref Lock_48); }).Start();
            //new Thread(() => { WriteToFileSC(48, file_SC49, ref DataQueue_SC49, ref Lock_49); }).Start();
            //new Thread(() => { WriteToFileSC(49, file_SC50, ref DataQueue_SC50, ref Lock_50); }).Start();

            //new Thread(() => { WriteToFileSC(50, file_SC51, ref DataQueue_SC51, ref Lock_51); }).Start();
            //new Thread(() => { WriteToFileSC(51, file_SC52, ref DataQueue_SC52, ref Lock_52); }).Start();
            //new Thread(() => { WriteToFileSC(52, file_SC53, ref DataQueue_SC53, ref Lock_53); }).Start();
            //new Thread(() => { WriteToFileSC(53, file_SC54, ref DataQueue_SC54, ref Lock_54); }).Start();
            //new Thread(() => { WriteToFileSC(54, file_SC55, ref DataQueue_SC55, ref Lock_55); }).Start();
            //new Thread(() => { WriteToFileSC(55, file_SC56, ref DataQueue_SC56, ref Lock_56); }).Start();
            //new Thread(() => { WriteToFileSC(56, file_SC57, ref DataQueue_SC57, ref Lock_57); }).Start();
            //new Thread(() => { WriteToFileSC(57, file_SC58, ref DataQueue_SC58, ref Lock_58); }).Start();
            //new Thread(() => { WriteToFileSC(58, file_SC59, ref DataQueue_SC59, ref Lock_59); }).Start();
            //new Thread(() => { WriteToFileSC(59, file_SC60, ref DataQueue_SC60, ref Lock_60); }).Start();

            //new Thread(() => { WriteToFileSC(60, file_SC61, ref DataQueue_SC61, ref Lock_61); }).Start();
            //new Thread(() => { WriteToFileSC(61, file_SC62, ref DataQueue_SC62, ref Lock_62); }).Start();
            //new Thread(() => { WriteToFileSC(62, file_SC63, ref DataQueue_SC63, ref Lock_63); }).Start();
            //new Thread(() => { WriteToFileSC(63, file_SC64, ref DataQueue_SC64, ref Lock_64); }).Start();
            //new Thread(() => { WriteToFileSC(64, file_SC65, ref DataQueue_SC65, ref Lock_65); }).Start();
            //new Thread(() => { WriteToFileSC(65, file_SC66, ref DataQueue_SC66, ref Lock_66); }).Start();
            //new Thread(() => { WriteToFileSC(66, file_SC67, ref DataQueue_SC67, ref Lock_67); }).Start();
            //new Thread(() => { WriteToFileSC(67, file_SC68, ref DataQueue_SC68, ref Lock_68); }).Start();



            //new Thread(() => { WriteToFileAsynC(1, file_asyn1, ref DataQueue_asyn_1, ref Lock_asyn_1); }).Start();
            //new Thread(() => { WriteToFileAsynC(2, file_asyn2, ref DataQueue_asyn_2, ref Lock_asyn_2); }).Start();
            //new Thread(() => { WriteToFileAsynC(3, file_asyn3, ref DataQueue_asyn_3, ref Lock_asyn_3); }).Start();
            //new Thread(() => { WriteToFileAsynC(4, file_asyn4, ref DataQueue_asyn_4, ref Lock_asyn_4); }).Start();
            //new Thread(() => { WriteToFileAsynC(5, file_asyn5, ref DataQueue_asyn_5, ref Lock_asyn_5); }).Start();
            //new Thread(() => { WriteToFileAsynC(6, file_asyn6, ref DataQueue_asyn_6, ref Lock_asyn_6); }).Start();
            //new Thread(() => { WriteToFileAsynC(7, file_asyn7, ref DataQueue_asyn_7, ref Lock_asyn_7); }).Start();
            //new Thread(() => { WriteToFileAsynC(8, file_asyn8, ref DataQueue_asyn_8, ref Lock_asyn_8); }).Start();
            //new Thread(() => { WriteToFileAsynC(9, file_asyn9, ref DataQueue_asyn_9, ref Lock_asyn_9); }).Start();
            //new Thread(() => { WriteToFileAsynC(10, file_asyn10, ref DataQueue_asyn_10, ref Lock_asyn_10); }).Start();
            //new Thread(() => { WriteToFileAsynC(11, file_asyn11, ref DataQueue_asyn_GNC1, ref Lock_asyn_11); }).Start();
            //new Thread(() => { WriteToFileAsynC(12, file_asyn12, ref DataQueue_asyn_GNC2, ref Lock_asyn_12); }).Start();
        }

        public void FileClose()
        {
            SaveOn = false;
            Trace.WriteLine("Start FileClose!\n");
            Thread.Sleep(500);
            //           WriteFileThread.Abort();
            try
            {
                foreach (var item in myFileList_dat)
                {
                    item.Close();
                }
                foreach (var item in myFileList_txt)
                {
                    item.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message + "From FileCLose()");
            }
        }


        private void WriteToFileSC(int key, object file, ref Queue<byte[]> myQueue, ref ReaderWriterLockSlim myLock)
        {
            Trace.WriteLine("Start WriteToFileSC Thread:" + key.ToString());
            FileStream myfile = (FileStream)file;
            BinaryWriter bw = new BinaryWriter(myfile);
            //     FileInfo fileInfo;

            while (SaveOn)
            {
                if (myQueue.Count() > 0)
                {
                    try
                    {
                        myLock.EnterReadLock();
                        bw.Write(myQueue.Dequeue());
                        bw.Flush();
                        myLock.ExitReadLock();

                        #region 分割文件，防止文件过大
                        long FileSizeMB = myfile.Length / (1024 * 1024 * 1024);
                        if (FileSizeMB > 1)
                        {
                            myFileList_dat[key].Flush();

                            string Path2 = myFileList_dat[key].Name;
                            int count = Path2.LastIndexOf("\\");
                            Path2 = Path2.Substring(0, count + 1);

                            myFileList_dat[key].Close();

                            FileStream newFile;
                            string timestr = string.Format("{0}-{1:D2}-{2:D2} {3:D2}：{4:D2}：{5:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            string filename = Path2 + timestr + ".dat";
                            newFile = new FileStream(filename, FileMode.Create);

                            myFileList_dat.Remove(myFileList_dat[key]);
                            myFileList_dat.Insert(key, newFile);

                            break;
                            //break跳出循环会执行新线程
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        bw.Close();
                        Trace.WriteLine(myQueue.Count());
                        Trace.WriteLine(e.Message);
                        break;
                    }
                }
                else
                {
                    Thread.Sleep(200);
                    //                  Trace.WriteLine("Queue0 is empty!!");
                }
            }
            bw.Close();
            Trace.WriteLine("Leaving WriteToFileSC:" + key.ToString());

            if (SaveOn) WriteToFileSC(key, myFileList_dat[key], ref myQueue, ref myLock);

        }


        private void WriteToFileAsynC(int key, object file, ref Queue<string> myQueue, ref ReaderWriterLockSlim myLock)
        {
            Trace.WriteLine("Start WriteToFileAsync Thread:" + key.ToString());
            FileStream myfile = (FileStream)file;
            StreamWriter bw = new StreamWriter(myfile);
            //      FileInfo fileInfo;
            while (SaveOn)
            {
                if (myQueue.Count() > 0)
                {
                    try
                    {
                        myLock.EnterReadLock();
                        bw.Write(myQueue.Dequeue());
                        bw.Flush();
                        myLock.ExitReadLock();

                        #region 分割文件，防止文件过大
                        long FileSizeMB = myfile.Length / (1024 * 1024);
                        if (FileSizeMB > 10)
                        {
                            myFileList_txt[key].Flush();

                            string Path2 = myFileList_txt[key].Name;
                            int count = Path2.LastIndexOf("\\");
                            Path2 = Path2.Substring(0, count + 1);

                            myFileList_txt[key].Close();

                            FileStream newFile;
                            string timestr = string.Format("{0}-{1:D2}-{2:D2} {3:D2}：{4:D2}：{5:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            string filename = Path2 + timestr + ".txt";
                            newFile = new FileStream(filename, FileMode.Create);

                            myFileList_txt.Remove(myFileList_txt[key]);
                            myFileList_txt.Insert(key, newFile);

                            break;
                            //break跳出循环会执行新线程
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        bw.Close();
                        Trace.WriteLine(myQueue.Count());
                        Trace.WriteLine(e.Message);
                        break;
                    }
                }
                else
                {
                    Thread.Sleep(200);
                    //                  Trace.WriteLine("Queue0 is empty!!");
                }
            }
            bw.Close();
            Trace.WriteLine("Leaving WriteToFileAsync:" + key.ToString());

            if (SaveOn) WriteToFileAsynC(key, myFileList_txt[key], ref myQueue, ref myLock);

        }
    }
}
