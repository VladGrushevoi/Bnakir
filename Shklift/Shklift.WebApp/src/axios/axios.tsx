import axios from 'axios'

export interface TransactionProps {
    FromCardNumber: string,
    FromCardCvv: string,
    FromCardShortExpire: string,
    AmountMoney: number,
    CardNumberReceiver : string
}

export interface TransactionResponse {
    Id?: string,
    FromCardNumber?: string,
    ToCardNumber?: string,
    AmountMoney?: string,
    DateOfOperation?: string,
    Commission?: string,
    IsConfirmTransaction: boolean 
}

export const SendTransaction = async (transactData : TransactionProps) => {
    console.log(JSON.stringify(transactData))
    const {data, status} = await axios.post<TransactionResponse>(
        "http://localhost:5029" + "/transaction/create", 
        JSON.stringify(transactData),
        {
            headers:{
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
    if(status != 200){
        return {
            IsConfirmTransaction: false,
        } as TransactionResponse
    }
    return data;
}