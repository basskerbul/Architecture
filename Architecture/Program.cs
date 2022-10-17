/*  На основе Диаграмы классов ModelElements, разработать классы: 
 *  Model Store, PoligonalModel (Texture, Poligon), Flash, Camera, Scene */

using System.Drawing;

interface IModelChangeObserver
{
    void ApplyUpdateModel();
}
public interface IModelChanger
{
    void NotifyChange(IModelChanger server);
}

public class ModelStore: IModelChanger
{
    public PoligonalModel Models;
    public Scene Schenes;
    public Flashe Flash;
    public Camera Cameras;
    private IModelChangeObserver changeObserver;

    public Scene GetScena(int scena) { return null; }
    public void NotifyChange(IModelChanger server) { }
}


public class Camera
{
    //public Point3D Location;
    //public Angle3D Angle;

    //public void Rotate(Angle3D angle) { }
    //public void Move(Point3D point) { }
}
public class Flashe
{
    //public Point3D Location;
    //public Angle3D Angle;
    public Color Color;
    public float Power;

    //public void Rotate(Angle3D angle) { }
    //public void Move(Point3D point) { }
}
public class Scene
{
    public int Id;
    public PoligonalModel Models;
    public Flashe Flash;

    public static int method1(int value) { return 0; }
    public static int method2(int value1, int value2) { return 0; }
}

public class PoligonalModel
{
    public Poligon Poligon;
    public Texture Texture;
}

public class Texture { }

public class Poligon
{
    //public Point3D Points; 
}