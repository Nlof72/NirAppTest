#include <matplot/matplot.h>
#include <msclr\marshal.h>
#include <cmath>

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;
using namespace matplot;

namespace MatplotLibCLR {
	public ref class Mock {};
	public ref class Graph {
	public:
		inline auto Plot(array<double>^ x, array<double>^ y, System::String^ line_spec)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			plot(x1, y1, line_spec1);
		}
		inline auto Plot(array<double>^ y, System::String^ line_spec)
		{
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			plot(y1, line_spec1);
		}
		inline auto Plot(Mock ax, array<double>^ x, array<double>^ y, System::String^ line_spec)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Plot(Mock ax, array<double>^ y, System::String^ line_spec)
		{
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Morebins(Mock h, double bin_increase)
		{
			double bin_increase1 = bin_increase;

		}
		inline auto Fewerbins(Mock h, double bin_decrease)
		{
			double bin_decrease1 = bin_decrease;

		}
		inline auto Geoplot()
		{
			geoplot();
		}
		inline auto Geolimits(array<double>^ latitude, array<double>^ longitude)
		{
			std::array<double, 2> latitude1 = { latitude[0], latitude[1], };
			std::array<double, 2> longitude1 = { longitude[0], longitude[1], };
			geolimits(latitude1, longitude1);
		}
		inline auto Geolimits(Mock ax, array<double>^ latitude, array<double>^ longitude)
		{
			std::array<double, 2> latitude1 = { latitude[0], latitude[1], };
			std::array<double, 2> longitude1 = { longitude[0], longitude[1], };

		}
		inline auto Fcontour(Mock fn, array<double>^ xy_range, array<double>^ levels, System::String^ line_spec)
		{
			std::array<double, 4> xy_range1 = { xy_range[0], xy_range[1], xy_range[2], xy_range[3], };
			std::vector<double> levels1(levels->Length);
			for (int i = 0; i < levels->Length; i++) {
				levels1[i] = levels[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Fcontour(Mock fn, System::String^ line_spec)
		{
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Fcontour(Mock ax, Mock fn, array<double>^ xy_range, array<double>^ levels, System::String^ line_spec)
		{
			std::array<double, 4> xy_range1 = { xy_range[0], xy_range[1], xy_range[2], xy_range[3], };
			std::vector<double> levels1(levels->Length);
			for (int i = 0; i < levels->Length; i++) {
				levels1[i] = levels[i];
			}
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Fcontour(Mock ax, Mock fn, System::String^ line_spec)
		{
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);

		}
		inline auto Fsurf(Mock fn, array<double>^ x_range, array<double>^ y_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 2> x_range1 = { x_range[0], x_range[1], };
			std::array<double, 2> y_range1 = { y_range[0], y_range[1], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock funx, Mock funy, Mock funz, array<double>^ u_range, array<double>^ v_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 2> u_range1 = { u_range[0], u_range[1], };
			std::array<double, 2> v_range1 = { v_range[0], v_range[1], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock fn, array<double>^ xy_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 4> xy_range1 = { xy_range[0], xy_range[1], xy_range[2], xy_range[3], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock fn, Mock xy_range, System::String^ line_spec, double mesh_density)
		{
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock funx, Mock funy, Mock funz, array<double>^ uv_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 4> uv_range1 = { uv_range[0], uv_range[1], uv_range[2], uv_range[3], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}


		inline auto Fsurf(Mock funx, Mock funy, Mock funz, Mock uv_range, System::String^ line_spec, double mesh_density)
		{
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock ax, Mock fn, array<double>^ x_range, array<double>^ y_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 2> x_range1 = { x_range[0], x_range[1], };
			std::array<double, 2> y_range1 = { y_range[0], y_range[1], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock ax, Mock funx, Mock funy, Mock funz, array<double>^ u_range, array<double>^ v_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 2> u_range1 = { u_range[0], u_range[1], };
			std::array<double, 2> v_range1 = { v_range[0], v_range[1], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock ax, Mock fn, array<double>^ xy_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 4> xy_range1 = { xy_range[0], xy_range[1], xy_range[2], xy_range[3], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Fsurf(Mock ax, Mock funx, Mock funy, Mock funz, array<double>^ uv_range, System::String^ line_spec, double mesh_density)
		{
			std::array<double, 4> uv_range1 = { uv_range[0], uv_range[1], uv_range[2], uv_range[3], };
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}


		inline auto Fsurf(Mock ax, Mock funx, Mock funy, Mock funz, Mock uv_range, System::String^ line_spec, double mesh_density)
		{
			std::string_view line_spec1 = (char*)(void*)Marshal::StringToHGlobalAnsi(line_spec);
			double mesh_density1 = mesh_density;

		}
		inline auto Text(array<double>^ x, array<double>^ y, Mock texts)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}

		}
		inline auto Text(array<double>^ x, array<double>^ y, System::String^ str)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view str1 = (char*)(void*)Marshal::StringToHGlobalAnsi(str);
			text(x1, y1, str1);
		}
		inline auto Text(Mock ax, array<double>^ x, array<double>^ y, Mock texts)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}

		}
		inline auto Text(Mock ax, array<double>^ x, array<double>^ y, System::String^ str)
		{
			std::vector<double> x1(x->Length);
			for (int i = 0; i < x->Length; i++) {
				x1[i] = x[i];
			}
			std::vector<double> y1(y->Length);
			for (int i = 0; i < y->Length; i++) {
				y1[i] = y[i];
			}
			std::string_view str1 = (char*)(void*)Marshal::StringToHGlobalAnsi(str);

		}
		inline auto Line(double x1, double y1, double x2, double y2)
		{
			double x11 = x1;
			double y11 = y1;
			double x21 = x2;
			double y21 = y2;
			line(x11, y11, x21, y21);
		}
		inline auto Line(Mock ax, double x1, double y1, double x2, double y2)
		{
			double x11 = x1;
			double y11 = y1;
			double x21 = x2;
			double y21 = y2;

		}
		inline auto Show()
		{
			show();
		}
		inline auto Show(Mock f)
		{

		}
		inline auto Save(std::string filename)
		{
			std::string filename1 = filename;
			save(filename1);
		}
		inline auto Save(Mock f, std::string filename, std::string format)
		{
			std::string filename1 = filename;
			std::string format1 = format;

		}
		inline auto Save(std::string filename, std::string format)
		{
			std::string filename1 = filename;
			std::string format1 = format;
			save(filename1, format1);
		}
		inline auto Save(Mock f, std::string filename)
		{
			std::string filename1 = filename;

		}
	};
}