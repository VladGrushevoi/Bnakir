import { Card } from "../../components/Card/Card"

interface MainPageProps {

}

export const MainPage = ({ }: MainPageProps) => {

    return (
        <>
            <section className="h-4/5">
                <div
                    className="h-full"
                >
                    <div className="flex justify-center pt-24 flex-wrap">
                        <Card isSender={true}/>
                        <Card isSender={false}/>
                    </div>
                </div>
            </section>
        </>
    )
}