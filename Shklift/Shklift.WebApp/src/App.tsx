import React from 'react'
import './App.css'
import { Header } from './components/Header/Header'
import { MainPage } from './pages/MainPage/MainPage'

function App(): React.JSX.Element {

    return (
        <>
            <div className='container h-screen bg-gray-100'>
                <Header />
                <MainPage />
            </div>
        </>
    )
}

export default App
