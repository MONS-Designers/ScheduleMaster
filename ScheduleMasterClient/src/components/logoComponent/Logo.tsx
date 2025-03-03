import './Logo.css';
import calendar from '../../assets/calendar.png';
import clock from '../../assets/clock.png';
import sm from '../../assets/sm.png';

const Logo = () => {
    return (
        <div className="image-stack">
            <img className="image-top" src={sm} alt="Top" />
            <img className="image-mid" src={calendar} alt="Mid" />
            <img className="image-bottom" src={clock} alt="Bottom" />
        </div>
    );
};

export default Logo;
