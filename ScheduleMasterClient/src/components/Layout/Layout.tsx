import Header from "./Header"
import Section from "./Section"
import SideToolsBar from "./SideToolsBar"

export const Layout = () => {
    return (
        <div style={{ display: 'flex', flexDirection: 'row' }}>
            <SideToolsBar />
            <div style={{ display: 'flex', flexDirection: 'column', width: '100vw' }}>
                <Header />
                <Section />
            </div>
        </div>
    )
}