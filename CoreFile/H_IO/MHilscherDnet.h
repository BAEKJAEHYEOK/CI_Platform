/* Generated by Together */
/* written by jsMoon on 2004.03.17 */

#ifndef MHILSCHERDNET_H
#define MHILSCHERDNET_H
#include "IIO.h"
#include "CIFUSER.h"

#ifdef VIRTUAL_DEVICE_IO
#import "Server.tlb" no_namespace
#endif

#define INPUT_ORIGIN		1000
#define OUTPUT_ORIGIN		2000
#define OUTPUT_END			3000

// #define SUCCESS		0
#define ERROR_ID	-1

#define TRUE		1
#define FALSE		0

const BYTE highbitsMask[8] =
	{
		0x00,  //0000 0000
		0x01,  //0000 0001
		0x03,  //0000 0011
		0x07,  //0000 0111
		0x0F,  //0000 1111
		0x1F,  //0001 1111
		0x3F,  //0011 1111
		0x7F,  //0111 1111
		
	};

const BYTE lowbitsMask[8] =
	{
		0xFE,  //1111 1110
		0xFC,  //1111 1100
		0xF8,  //1111 1000
		0xF0,  //1111 0000
		0xE0,  //1110 0000
		0xC0,  //1100 0000
		0x80,  //1000 0000
		0x00,  //0000 0000
	};

typedef

 /**
  * Devicenet�� Master�� Slave�� ���¸� Devicenet ���� ���� �о���� ���� ����Ÿ ����ü�̴�. 
  */
 struct DNM_DIAGNOSTICStag {
  /** bit field to show network and DEVICE main errors */
  struct  GLOBAL_BITS {
    unsigned char bCtrl     : 1; /* wrong parameterization                  */
    unsigned char bAClr     : 1; /* auto_clear activated                    */
    unsigned char bNonExch  : 1; /* no data exchange to at least on station */
    unsigned char bFatal    : 1; /* fatal error occured                     */
    unsigned char bEvent    : 1; /* bus error events occured                */
    unsigned char bNRdy     : 1; /* host program not ready                  */
    unsigned char bDupMAC   : 1; /* duplicate MAC id detected check failed  */
    unsigned char bPerDup   : 1; /* duplicate MAC Id check active           */
  } bGlobalBits;

  /** global state for the different DEVICE main states */
  unsigned char   bDNM_state;
  #define OFFLINE  0x00
  #define STOP     0x40
  #define CLEAR    0x80
  #define OPERATE  0xC0

  /** location of error and error code */
  struct T_ERRORS
  {
    unsigned char bErrDevAdr; /* 0-63, 255 */
    #define MST_ERR  0xFF

    unsigned char bErrEvent;   /* see #defines */

    /* DEVICE internal errors */

    #define TASK_F_UNKNOWN_MODE                     52 /* unknown handshake mode configured */
    #define TASK_F_BAUDRATE_OUT_RANGE               53 /* configured batudrate not supported */
    #define TASK_F_OWN_MAC_ID_OUT_RANGE             54 /* DEVICE MAC-ID out of range */
    #define TASK_F_DUPLICATE_MAC_ID                 57 /* a duplicate MAC-ID detected */
    #define TASK_F_NO_DEV_TAB                       58 /* data base in the DEVICE has no entries included */
    #define TASK_F_ADR_DOUBLE                       59 /* double MAC-ID configured internally */
    #define TASK_F_DATA_SET_FIELD_LEN               60 /* size of one device data set invalid */
    #define TASK_F_PRED_MST_SL_ADD_LEN              61 /* offset table for predef.mst slave conn. invalid */
    #define TASK_F_PRED_MSTSL_CFG_FIELD_LEN         62 /* configur. table length for predef.mst.slave conn. invalid */
    #define TASK_F_PRED_MST_SL_ADD_TAB_INCONS       63 /* offset table do not correspond to I/O configuration table */
    #define TASK_F_EXPL_PRM_FIELD_LEN               64 /* size indicator of parameter data table corrupt */
    #define TASK_F_PRED_MSTSL_CFG_ADD_INPUT_INCONS  65 /* num of inputs in add tab not equal I/O configuration */
    #define TASK_F_PRED_MSTSL_CFG_ADD_OUTPUT_INCONS 66 /* num of outputs in add tab not equal I/O configuration */
    #define TASK_F_UNKNOWN_DATA_TYPE                67 /* unknown data type in I/O configuration */
    #define TASK_F_MODULE_DATA_SIZE                 68 /* data type does not correspond to its configured length */
    #define TASK_F_OUTPUT_OFF_RANGE                 69 /* configured output offset address out of range */
    #define TASK_F_INPUT_OFF_RANGE                  70 /* configured input offset address out of */
    #define TASK_F_WRONG_TYPE_OF_CONNECTION         71 /* one predefined connection type is unknown */
    #define TASK_F_TYPE_CONNECTION_REDEFINITION     72 /* multiple connections defined in parallel */
    #define TASK_F_EXP_PACKET_LESS_PROD_INHIBIT     73 /* configured EXP_PCKT_RATE less then PROD_INHIBIT_TIME */
    #define TASK_F_PRM_FIELD_LEN_INCONSISTENT       74 /* parameter field DNM_SET_ATTR_DATA in data set inconsitent */
    #define TASK_F_NO_CAN                           75 /* no device responding on CAN network at cfg.baudrate */
    #define TASK_F_REG_FRAG_TIMEOUT_OUT_OF_RANGE    76 /* usRegFragTimeout out of range */

  } tError;

  /** counter for the bus error events */
  unsigned short  usBus_Error_Cnt;

  /** counter of bus off reports of the CAN chip */
  unsigned short  usBus_Off_Cnt;

  /** reserved area */
  struct SVR_STATUS
  {
    unsigned char bSrvExpl   : 1; /* server explicit connection established */
    unsigned char bSrvIO     : 1; /* server I/O poll connection established */
    unsigned char bReserved  : 6; /* reserved bits */
  } bSrvStatus;
  #define SRV_EXPL 0x01
  #define SRV_IO   0x02

  unsigned char   abReserved[7];

  /* Bit-Ready, Cfg-Ready and diagnostic display of the devices */
  /** device configuration area */
  unsigned char   abDv_cfg  [16];  /* device configuration area */
  /** device state information area */
  unsigned char   abDv_state[16];  /* device state information area */
  /** device diagnostic area */
  unsigned char   abDv_diag [16];  /* device diagnostic area */

} DNM_DIAGNOSTICS;


class MHilscherDnet : public IIO {

	/** Error Base */
	int	m_iErrorBase;

	// Object ID
	int m_iObjectID;	

	/** MAttachAcf Log File Handler */
	MLog	*m_plogMng;

    /** Board number (0..3)   */
    unsigned short m_usBoardNumber;

    /**
     * Device�� Open �Ǿ������� Ȯ���ϴ� Flag : m_BDeviceOpened = TRUE if it is opened; m_BDeviceOpened = FALSE if it is not opened.
     */
    BOOL m_BDeviceOpened;

    /** I/O Device�� status�� Update�Ǵ� �迭 */
    BYTE m_ucOutgoingBuffer[MAX_DEVICE * 4];

    /** I/O Device�� ����� Digital Command�� ����ִ� �迭 */
	BYTE m_ucIncomingBuffer[MAX_DEVICE * 4];

	/* Device�� ���� ������ ������ ���� */
	DN_STATUS	m_tblDnStatus;

public:

	/** Default Constructor  
	 * @stereotype constructor
	 */
	MHilscherDnet();

	/** Standard Constructor  
	 * @stereotype constructor
	 * @param iObjectID : Component�� Object ID
	 * @param iErrorBase : Error ���� Offset
	 * @param strFullFileName : �α� ���� �̸� �� Path
	 * @param ucLevel : �α� ����
						DEF_MLOG_NONE_LOG_LEVEL    : 0x00;	// Log �� ��
						DEF_MLOG_ERROR_LOG_LEVEL   : 0x01;	// Error���� Log
						DEF_MLOG_WARNING_LOG_LEVEL : 0x02;	// Warning ���� Log
						DEF_MLOG_NORMAL_LOG_LEVEL  : 0x04;	// ���� ���� ���� Log
	  * @param iDays : �α� ���� ���� �Ⱓ
	  * @param usBoardNumber : Board Number
	 */
	MHilscherDnet(
		int				iObjectID, 
		int				iErrorBase, 
		CString			strFullFileName, 
		BYTE			ucLevel, 
		int				iDays = 30, 
		unsigned short	usBoardNumber = 0
	);

     /** ������ Contructor 
     * MHILSCHERDNET ��ü�����ڷν� Board Number�� parameter�� �޴´�.
     * @param usBoardNumber : Board Number
     * @return 0 = Success, �׿� = Error Number
	 * @stereotype constructor
     */
	MHilscherDnet(unsigned short usBoardNumber);

	/** @stereotype Destructor */
	virtual ~MHilscherDnet();

	// �Ʒ� �Լ����� IIO Class�� ���� �Ǿ� ������ ���� ������ IIO.h�� �����ϼ���.
    /**
     * Hilscher Board���� Communication�� ���� Driver�� Open�ϸ�, Board�� �ʱ�ȭ�ϰ� ��� ��� ���°� �ǰ� �Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int Initialize();

    /**
     * I/O Device�� Digital Status (Bit) ��  �о�帰��.
     * @precondition �� �Լ��� �����ϱ� ���� initialize �Լ��� �̸� ����Ǿ���� �Ѵ�.
     * @param usIOAddr : IO Address
	 * @param pbVal    : IO ��
     * @return  0      : SUCCESS
	            else   : Device \Error �ڵ� 
     */
	int GetBit(unsigned short usIOAddr, BOOL *pbval);

    /**
     * Hilscher Board���� Communication�� �����ϰ� Device Driver�� Close�Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int Terminate();

    /**
     * I/O Device�� Digital Status (Bit) �� �о�鿩 bit ���� �ƱԸ�Ʈ�� �����Ѵ�.
     * @precondition �� �Լ��� �����ϱ� ���� initialize �Լ��� �̸� ����Ǿ���� �Ѵ�.
     * @param usIOAddr : IO Address
	 * @param pbVal    : TRUE : ���� 1 ��, FALSE : ���� 0 ��
     * @return  0      : SUCCESS
	            else   : Device Error �ڵ� 
     */
   int IsOn(unsigned short usIOAddr, BOOL *pbVal);

   /**
     * I/O Device�� Digital Status (Bit) �� �о�鿩 bit ���� �ƱԸ�Ʈ�� �����Ѵ�.
     * @precondition �� �Լ��� �����ϱ� ���� initialize �Լ��� �̸� ����Ǿ���� �Ѵ�.
     * @param usIOAddr : IO Address
	 * @param pbVal    : TRUE : ���� 0 ��, FALSE : ���� 1 ��
     * @return  0      : SUCCESS
	            else   : Device Error �ڵ� 
     */
	int IsOff(unsigned short usIOAddr, BOOL *pbVal);

    /**
     * Output Device�� On Command (Bit = 1) �� ������.
     * @param usIOAddr : IO Address
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputOn(unsigned short usIOAddr);

    /**
     * Output Device�� Off Command (Bit = 0) �� ������.
     * @param usIOAddr : IO Address
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputOff(unsigned short usIOAddr);

    /**
     * Output Device�� Digital Status�� Set�̸� (Bit = 0), Output Device�� On Command (Bit = 1) �� ������,
     * Output Device�� Digital Status�� Clear�̸� (Bit = 1), Output Device�� Off Command (Bit = 0) �� ������.
     * @param usIOAddr : IO Address
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputToggle(unsigned short usIOAddr);

    /**
     * ���ӵ� 8���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue pointer�� �Ѱ��ش�.
     * @param usIOAddr : ���ӵ� 8���� IO Address�� �����ϴ� IO Address
     * @param pcValuse : ���ӵ� 8���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue�� �����Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int GetByte(unsigned short usIOAddr, BYTE & pcValue);

    /**
     * ���ӵ� 8���� IO Address�� ������ Output Device�鿡 On or Off Command�� ������.
     * @param usIOAddr : ���ӵ� 8���� IO Address�� �����ϴ� IO Address
     * @param pcValuse : Output Device�� ���� Command�� �����ϰ� �ִ� �����̴�.
     * @return 0 = Success, �׿� = Error Number
     */
    int PutByte(unsigned short usIOAddr, BYTE pcValue);

    /**
     * ���ӵ� 16���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue pointer�� �Ѱ��ش�.
     * @param usIOAddr : ���ӵ� 16���� IO Address�� �����ϴ� IO Address
     * @param pwValuse : ���ӵ� 16���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue�� �����Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int GetWord(unsigned short usIOAddr, WORD & pwValue);

    /**
     * ���ӵ� 16���� IO Address�� ������ Output Device�鿡 On or Off Command�� ������.
     * @param usIOAddr : ���ӵ� 16���� IO Address�� �����ϴ� IO Address
     * @param pwValuse : Output Device�� ���� Command�� �����ϰ� �ִ� �����̴�.
     * @return 0 = Success, �׿� = Error Number
     */
    int PutWord(unsigned short usIOAddr, WORD pwValue);

    /**
     * I/O Device�� Digital Status (Bit) ��  �о�帰��.
     * @precondition �� �Լ��� �����ϱ� ���� initialize �Լ��� �̸� ����Ǿ���� �Ѵ�.
     * @param strIOAddr : IO Address String (ex, "1000:START_SW")
	 * @param pbVal    : IO ��
     * @return  0      : SUCCESS
	            else   : Device \Error �ڵ� 
     */
    int GetBit(CString strIOAddr, BOOL *pbVal);

    /**
     * I/O Device�� Digital Status (Bit) �� �о�鿩 Bit = 1�̸�, TRUE(1)�� Return�ϰ�, Bit = 0�̸� FALSE(0)�� Return�Ѵ�.
     * @precondition �� �Լ��� �����ϱ� ���� initialize �Լ��� �̸� ����Ǿ���� �Ѵ�.
     * @param strIOAddr : IO Address String (ex, "1000:START_SW")
	 * @param pbVal    : IO ��
     * @return  0      : SUCCESS
	            else   : Device \Error �ڵ� 
     */
    int IsOn(CString strIOAddr, BOOL *pbVal);

    /**
     * Output Device�� On Command (Bit = 1) �� ������.
     * @param strIOAddr : IO Address String (ex, "1000:START_SW")
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputOn(CString strIOAddr);

    /**
     * Output Device�� Off Command (Bit = 0) �� ������.
     * @param strIOAddr : IO Address String (ex, "1000:START_SW")
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputOff(CString strIOAddr);

    /**
     * Output Device�� Digital Status�� Set�̸� (Bit = 0), Output Device�� On Command (Bit = 1) �� ������,
     * Output Device�� Digital Status�� Clear�̸� (Bit = 1), Output Device�� Off Command (Bit = 0) �� ������.
     * @param strIOAddr : IO Address String (ex, "1000:START_SW")
     * @return 0 = Success, �׿� = Error Number
     */
    int OutputToggle(CString strIOAddr);

    /**
     * ���ӵ� 8���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue pointer�� �Ѱ��ش�.
     * @param strIOAddr : ���ӵ� 8���� IO Address�� �����ϴ� IO Address�� String Type (ex, "1000:START_SW")
     * @param pcValuse : ���ӵ� 8���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue�� �����Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int GetByte(CString strIOAddr, BYTE & pcValue);

    /**
     * ���ӵ� 8���� IO Address�� ������ Output Device�鿡 On or Off Command�� ������.
     * @param strIOAddr : ���ӵ� 8���� IO Address�� �����ϴ� IO Address�� String Type (ex, "1000:START_SW")
     * @param pcValuse : Output Device�� ���� Command�� �����ϰ� �ִ� �����̴�.
     * @return 0 = Success, �׿� = Error Number
     */
    int PutByte(CString strIOAddr, BYTE pcValue);

    /**
     * ���ӵ� 16���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue pointer�� �Ѱ��ش�.
     * @param strIOAddr : ���ӵ� 16���� IO Address�� �����ϴ� IO Address�� String Type (ex, "1000:START_SW")
     * @param pwValuse : ���ӵ� 16���� IO Address�� ������ Input Device ���� Digital Status�� �о�鿩 pcValue�� �����Ѵ�.
     * @return 0 = Success, �׿� = Error Number
     */
    int GetWord(CString strIOAddr, WORD & pwValue);

    /**
     * ���ӵ� 16���� IO Address�� ������ Output Device�鿡 On or Off Command�� ������.
     * @param strIOAddr : ���ӵ� 16���� IO Address�� �����ϴ� IO Address�� String Type (ex, "1000:START_SW")
     * @param pwValuse : Output Device�� ���� Command�� �����ϰ� �ִ� �����̴�.
     * @return 0 = Success, �׿� = Error Number
     */
    int PutWord(CString strIOAddr, WORD pwValue);

	/**
     * Incoming Buffer�� Update�ϰ�, Outgoing Buffer�� ������ Physical I/O�� �����ϴ� IOThread�� Run�Ѵ�.
     */
    void RunIOThread();

	/**
	 * Master ��� �� Slave ��� ���� ������ ���´�.
	 *
	 * @param  DnStatus : �����Ϳ� 64���� Slave�� ���� ���� ���� ����ü
	 * @return 0		= ��� ����
			   others	= �ϳ��� ����
	 */
	int DnStatusGet(DN_STATUS DnStatus);

private:
	/**
     * String Type I/O Address�� unsigned short type���� ��ȯ �Ͽ� usIOAddr�� I/O Address�� return.
	 * @param strIOAddr : String Type I/O Address (ex, "1000:START_SW")
	 * @param usIOAddr : unsigned short type I/O Address
     * @return 0 = Success, �׿� = Error Number
     */
    int IOAddrInterpreter(CString strIOAddr, unsigned short & usIOAddr);

	/**
     * Thread�ν� InputData[]�� Update�ϰ�, OutputData[]�� Physical I/O�� �����Ѵ�.
     */	
	UINT IOThread(LPVOID lParam);

	static DWORD WINAPI EntryPoint(LPVOID pParam);

	/**
	 * Master ��� �� Slave ��� ���� üũ
	 *
	 * @param ubMacID : ��� Slave Mac Address
              -1      : ��� Slave üũ (Default)
	 * @return 0		= SUCCESS
			   others	= ERROR Code
	 */
	int dnStatusCheck(unsigned char ucMacID = 0xff);

	/**
	 * Master ��� �� Slave ��� ���� üũ
	 *
	 * @return 0		= SUCCESS
			   others	= ERROR Code
	 */
	int returnDnetStatus();
    
   /**************** Common Interface ************************************/
public :

   /**
     * Error Code Base�� �����Ѵ�. 
	 *
	 * @param	iErrorBase : (OPTION=0) ������ Error Base ��
     */
    virtual void SetErrorBase(int iErrorBase = 0);

    /**
     * Error Code Base�� �д´�. 
	 *
	 * @return	int : Error Base ��
     */
    virtual int GetErrorBase(void) const;


   /**
     * Object ID�� �����Ѵ�. 
	 *
	 * @param	iObjectID : ������ Object ID ��
     */
    virtual void SetObjectID(int iObjectID);

    /**
     * Object ID�� �д´�. 
	 *
	 * @return	int : Object ID ��
     */
    virtual int GetObjectID(void);
	
	/** 
	 * Log Class�� ��ü Pointer�� �����Ѵ�.
	 *
	 * @param		*pLogObj: ������ Log Class�� ��ü Pointer
	 * @return		Error Code : 0 = Success, �� �� = Error
	 */
	virtual int SetLogObject(MLog *pLogObj);

   /**
     * Log File�� ���õ� attribute�� �����Ѵ�.
     *
	 * @param	iObjectID : ObjectID
     * @param	strFileName : file path �� file name�� ������ string
     * @param	ucLevel : log level ���� bitwise ����
     * @param	iDays : (OPTION=30) ���� set�Ǿ� �ִ� log file ������
     * @return	Error Code : 0 = Success, �� �� = Error
     */
    virtual int SetLogAttribute (int iObjectID, CString strFullFileName, BYTE ucLevel, int iDays = 30);
    /**
     * ������ Log file�� �����Ѵ�.
     *
     * @return	Error Code : 0 = Success, �� �� = Error
     */

    virtual int DeleteOldLogFiles (void);

	/** 
	 * Log manager�� ��ȯ�Ѵ�.
	 *
	 * @return	MLog* : ��ȯ�� Log Manager Pointer
	 */
	virtual MLog* GetLogManager();	


	/** 
	 * Component�� Error Code Base�� ��ȯ�Ѵ�.
	 *
	 * @param		Error Code: ObjectID + Error Base 
	 * @return		ErrorBase�� ���ŵ� Component Error Code 
	 */
	int DecodeError(int iErrCode);

/*----------- Component ���� Private Method Start -------*/

private:
	/**
	 * Error Code �����ϱ�
	 *  +-----------+-------------------------+
	 *  | Object ID | Error Code + Error Base |
	 *  | (2 bytes) |        (2 bytes)        |
	 *  +-----------+-------------------------+
	 *
	 * @param	iErrCode : �߻��� Error Code
	 * @return	Error Code : Object ID (2bytes)�� Error Code + Error Base (2bytes)�� 4bytes�� ������ �ڵ�
	 */
	int generateErrorCode(int iErrCode);

#ifdef VIRTUAL_DEVICE_IO
	void VirtualIOExchange();
	void ShowMessage(_com_error &e);
	IVirtualDeviceNetPtr m_compDNet;
	IVirtualDeviceNet	*m_compIIOBus;
#endif
};

#endif //MHILSCHERDNET_H