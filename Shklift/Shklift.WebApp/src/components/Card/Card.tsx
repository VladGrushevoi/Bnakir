import { CardInput } from "../Input/CardInput"
import { CvvInput } from "../Input/CvvInput"
import { DateInput } from "../Input/DateInput"

interface CardProps {
    isSender: boolean
}

export const Card = ({ isSender }: CardProps) => {
    return (
        <>
            <div
                className="w-[550px] h-[350px] mb-6 bg-slate-200 m-auto border rounded-3xl shadow-lg hover:shadow-pink-300"
            >
                <div className="block mt-8 w-full h-16 bg-black">
                    <div></div>
                </div>
                <div className="mt-8">
                    <p className="block text-center text-2xl">Номер банківської карти</p>
                    <div className="flex w-full h-10 justify-center">
                        <CardInput />
                        <CardInput />
                        <CardInput />
                        <CardInput />
                    </div>
                </div>
                {
                    isSender && <div className="flex w-full h-10 justify-center mt-8">
                    <span
                    >
                        <span className="text-2xl mr-2">Дата</span> 
                        <DateInput /> 
                    </span>
                    <span className="mx-12"></span>
                    <span
                    >
                        <span className="text-2xl mr-2">CVV</span> 
                        <CvvInput /> 
                    </span>
                </div>
                }
            </div>
        </>
    )
}